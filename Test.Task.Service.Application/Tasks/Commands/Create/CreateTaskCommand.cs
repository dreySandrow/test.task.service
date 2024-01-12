using MediatR;
using Test.Task.Service.Application.Models;

namespace Test.Task.Service.Application.Tasks.Commands.Create;

public sealed class CreateTaskCommand : IRequest<CreateTaskRequest>;
