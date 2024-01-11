using MediatR;
using Test.Task.Service.Application.Models;

namespace Test.Task.Service.Application.Tasks.Queries;

public sealed class GetTaskByIdQuery : IRequest<TaskDto>
{
    public Guid Id { get; set; }
}