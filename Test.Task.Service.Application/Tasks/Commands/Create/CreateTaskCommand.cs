using MediatR;

namespace Test.Task.Service.Application.Tasks.Commands.Create;

public sealed class CreateTaskCommand : IRequest<Guid>;
