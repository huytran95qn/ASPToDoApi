using AutoMapper;
using ToDo.API.Models.ToDo;

namespace ToDo.API.Configurations
{
    public class MappingToDO : Profile
    {
        public MappingToDO()
        {
            CreateMap<Data.ToDo, GetToDoDto>().ReverseMap();
            CreateMap<Data.ToDo, CreateToDoDto>().ReverseMap();
            CreateMap<Data.ToDo, UpdateToDoDto>().ReverseMap();
        }
    }
}
