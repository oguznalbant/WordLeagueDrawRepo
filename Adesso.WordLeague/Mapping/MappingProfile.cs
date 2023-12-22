using Adesso.WordLeague.DTO;
using Adesso.WordLeague.Entities;
using AutoMapper;

namespace Adesso.WordLeague.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //CreateMap<Team, TeamDto>().ReverseMap();
            CreateMap<Team, TeamDto>().ReverseMap();
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<Draw, DrawDto>().ReverseMap();
        }
    }
}
