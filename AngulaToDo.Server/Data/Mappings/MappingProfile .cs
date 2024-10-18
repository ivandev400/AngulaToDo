using AutoMapper;
using AngulaToDo.Server.Data.Dtos;
using AngulaToDo.Server.Models;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<UserForRegistrationDto, User>()
            .ForMember(u => u.UserName, opt => opt.MapFrom(x => x.Email));
    }
}