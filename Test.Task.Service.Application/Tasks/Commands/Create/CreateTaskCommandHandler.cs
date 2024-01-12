using AutoMapper;
using MediatR;
using Test.Task.Service.Application.Common;
using Test.Task.Service.Application.Tasks.Notifications;
using Test.Task.Service.Persistence;
using Threading = System.Threading.Tasks;

namespace Test.Task.Service.Application.Tasks.Commands.Create;

public sealed class CreateTaskCommandHandler(ApplicationDbContext applicationDbContext, IMapper mapper, IMediator mediator) : HandlerBase<CreateTaskCommand, Guid>(
    applicationDbContext, mapper, mediator)
{
    public override async Task<Guid> Handle(CreateTaskCommand request, CancellationToken cancellationToken)
    {
        
        var taskEntity = Domain.Entities.Task.Create();
        applicationDbContext.Tasks.Add(taskEntity);
        await applicationDbContext.SaveChangesAsync(cancellationToken);
        
        var notification = new TaskCreatedNotification();
        notification.Id = taskEntity.Id;

        await Mediator.Publish(notification, cancellationToken);
        return taskEntity.Id;
    }
}