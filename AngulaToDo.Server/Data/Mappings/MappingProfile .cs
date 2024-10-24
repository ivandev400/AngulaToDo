using AutoMapper;
using AngulaToDo.Server.Data.Dtos;
using AngulaToDo.Server.Models;
using Task = AngulaToDo.Server.Models.Task;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<UserForRegistrationDto, User>()
            .ForMember(u => u.UserName, opt => opt.MapFrom(x => x.Email));

        CreateMap<Task, TaskDto>();
        CreateMap<TaskDto, Task>()
            .ForAllMembers(options => options.Condition((src, dest, srcMember) => srcMember != null));

        CreateMap<CategoryDto, Category>();
        CreateMap<Category, CategoryDto>();
    }
}