using MediatR;
using Test.Task.Service.Application.Models;

namespace Test.Task.Service.Application.Tasks.Queries;

public class GetTaskByIdQuery : IRequest<TaskDto>
{
    public Guid Id { get; set; }
}