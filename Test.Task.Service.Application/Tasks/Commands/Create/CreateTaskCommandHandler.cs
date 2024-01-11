using AutoMapper;
using Test.Task.Service.Application.Common;
using Test.Task.Service.Persistence;
using Threading = System.Threading.Tasks;

namespace Test.Task.Service.Application.Tasks.Commands.Create;

public class CreateTaskCommandHandler(ApplicationDbContext applicationDbContext, IMapper mapper) : HandlerBase<CreateTaskCommand, Guid>(
    applicationDbContext, mapper)
{
    public override async Task<Guid> Handle(CreateTaskCommand request, CancellationToken cancellationToken)
    {
        var taskEntity = Domain.Entities.Task.Create();
        applicationDbContext.Tasks.Add(taskEntity);
        await applicationDbContext.SaveChangesAsync(cancellationToken);

        return taskEntity.Id;
    }
}