using AutoMapper;
using Test.Task.Service.Application.Models;

namespace Test.Task.Service.Application.Automapper;

public class AutoMapperConfiguration : Profile
{
    public AutoMapperConfiguration()
    {
        CreateMap<Domain.Entities.Task, TaskDto>();
    }   
}