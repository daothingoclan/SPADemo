using AutoMapper;
using SPADemo.Domain;
using SPADemo.Service.Dtos;

namespace SPADemo.Service.Mapping
{
    public class AutoMapperConfiguration : Profile
    {
        public AutoMapperConfiguration() : base()
        {
            Mapper.Initialize(x =>
            {
                x.CreateMap<Animal, AnimalDto>();
                x.CreateMap<AnimalDto, Animal>();
            });
        }
    }
}
