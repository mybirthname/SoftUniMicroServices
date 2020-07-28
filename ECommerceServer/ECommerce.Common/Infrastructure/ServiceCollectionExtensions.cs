using AutoMapper;
using ECommerce.Common.Messages;
using ECommerce.Common.Models;
using ECommerce.Common.Services;
using ECommerce.Common.Services.Identity;
using ECommerce.Common.Services.Identity.Interfaces;
using ECommerce.Common.Services.Messages;
using GreenPipes;
using Hangfire;
using Hangfire.SqlServer;
using MassTransit;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Reflection;
using System.Text;

namespace ECommerce.Common.Infrastructure
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddWebService<TDbContext>(
            this IServiceCollection services,
            IConfiguration configuration)
            where TDbContext : DbContext
        {
            services
                .AddDatabase<TDbContext>(configuration)
                .AddApplicationSettings(configuration)
                .AddTokenAuthentication(configuration)
                .AddAutoMapperProfile(Assembly.GetCallingAssembly())
                .AddHealthChecks(configuration)
                .AddControllers();

            return services;
        }

        //Sql server action is used for Database Resiliency, used for microservices-> max execute one query 10 times
        public static IServiceCollection AddDatabase<TDbContext>(
            this IServiceCollection services,
            IConfiguration configuration)
            where TDbContext : DbContext
        => services
            .AddScoped<DbContext, TDbContext>()
            .AddDbContext<TDbContext>(options => options
                .UseSqlServer(configuration.GetConnectionString("DefaultConnection"), sqlServerOptionsAction: action=> {
                    action.EnableRetryOnFailure(maxRetryCount: 10, maxRetryDelay: TimeSpan.FromSeconds(30), errorNumbersToAdd: null);
                }));

        public static IServiceCollection AddApplicationSettings(
            this IServiceCollection services,
            IConfiguration configuration)
            =>
            services.Configure<ApplicationSettings>(
                configuration.GetSection(nameof(ApplicationSettings)), config => config.BindNonPublicProperties = true);

        public static IServiceCollection AddTokenAuthentication(
            this IServiceCollection services,
            IConfiguration
             configuration,
            JwtBearerEvents events = null)
        {
            var secret = configuration
                .GetSection(nameof(ApplicationSettings))
                .GetValue<string>(nameof(ApplicationSettings.Secret));

            var key = Encoding.ASCII.GetBytes(secret);

            services
                .AddAuthentication(authentication =>
                {
                    authentication.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    authentication.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(bearer =>
                {
                    bearer.RequireHttpsMetadata = false;
                    bearer.SaveToken = true;
                    bearer.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(key),
                        ValidateIssuer = false,
                        ValidateAudience = false
                    };

                    if (events != null)
                    {
                        bearer.Events = events;
                    }
                });

            services.AddHttpContextAccessor();
            services.AddScoped<ICurrentUserService, CurrentUserService>();

            return services;

        }

        public static IServiceCollection AddHealthChecks(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            var healtchChecks = services.AddHealthChecks();
            healtchChecks.AddSqlServer(configuration.GetConnectionString("DefaultConnection"));

            healtchChecks.AddRabbitMQ(rabbitConnectionString: "amqp://rabbitmq:rabbitmq@rabbitmq/");

            return services;
        }

        public static IServiceCollection AddHangFireServices(this IServiceCollection services, IConfiguration configuration)
        {
            var options = new SqlServerStorageOptions
            {
                SlidingInvisibilityTimeout = TimeSpan.FromMinutes(5),
                QueuePollInterval = TimeSpan.FromSeconds(30)
            };
            services.AddHangfire(config => config
            
                                .SetDataCompatibilityLevel(CompatibilityLevel.Version_170)
                                .UseSimpleAssemblyNameTypeSerializer()
                                .UseRecommendedSerializerSettings()
                                .UseSqlServerStorage(configuration.GetConnectionString("DefaultConnection"), options));

            services.AddHangfireServer();
            services.AddHostedService<MessagesHostedService>();

            return services;
        }

        public static IServiceCollection AddMessaging(
            this IServiceCollection services,
            IConfiguration configuration,
            params Type[] consumers)
        {
            services
                .AddMassTransit(mt =>
                {
                    consumers.ForEach(consumer => mt.AddConsumer(consumer));

                    mt.AddBus(context => Bus.Factory.CreateUsingRabbitMq(rmq =>
                    {
                        rmq.Host("rabbitmq", host =>
                        {
                            host.Username("rabbitmq");
                            host.Password("rabbitmq");
                        });

                        rmq.UseHealthCheck(context);

                        consumers.ForEach(consumer => rmq.ReceiveEndpoint(consumer.FullName, endpoint =>
                        {
                            endpoint.PrefetchCount = 2;
                            endpoint.UseMessageRetry(retry => retry.Interval(10, 1000));

                            endpoint.ConfigureConsumer(context, consumer);
                        }));
                    }));
                })
                .AddMassTransitHostedService();

            return services;
        }


        public static IServiceCollection AddAutoMapperProfile(
            this IServiceCollection services,
            Assembly assembly)
            => services
                .AddAutoMapper(
                    (_, config) => config
                        .AddProfile(new MappingProfile(assembly)),
                    Array.Empty<Assembly>());



    }
}
