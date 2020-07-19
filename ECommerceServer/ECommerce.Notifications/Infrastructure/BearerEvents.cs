using Microsoft.AspNetCore.Authentication.JwtBearer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Notifications.Infrastructure
{
    public class BearerEvents
    {
        public static JwtBearerEvents Events
            => new JwtBearerEvents
            {
                OnMessageReceived = context =>
                {
                    var accessToken = context.Request.Query["access_token"];

                    var path = context.HttpContext.Request.Path;
                    if (!string.IsNullOrEmpty(accessToken) &&
                        path.StartsWithSegments("/notifications"))
                    {
                        context.Token = accessToken;
                    }

                    return Task.CompletedTask;
                }
            };
    }
}
