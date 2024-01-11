using MediatR;

namespace Test.Task.Service.Application.Tasks.Commands.Create;

public class CreateTaskCommand : IRequest<Guid>;
