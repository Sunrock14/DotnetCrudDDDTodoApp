using AutoMapper;

namespace TodoApp.Application.Automappers;

public class GeneralProfiler : Profile
{
    public GeneralProfiler()
    {
        CreateMap<Task, CreateTaskCommandResponse>();
        CreateMap<Task, UpdateTaskCommandRequest>().ReverseMap();
    }
}
