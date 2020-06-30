using AutoMapper;

namespace ECommerce.Common.Models.Interfaces
{
    public interface IMapFrom<T>
    {
        void Mapping(Profile mapper) => mapper.CreateMap(typeof(T), this.GetType());
    }
}
