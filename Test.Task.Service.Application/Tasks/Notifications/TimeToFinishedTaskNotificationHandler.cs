using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Test.Task.Service.Application.Common;
using Test.Task.Service.Domain.Enums;
using Test.Task.Service.Persistence;
using Threading = System.Threading.Tasks;

namespace Test.Task.Service.Application.Tasks.Notifications;

public class TimeToFinishedTaskNotificationHandler
    (ApplicationDbContext context, ILogger<TaskCreatedNotificationHandler> logger, IMediator mediator) :
    NotificationHandlerBase<TaskCreatedNotificationHandler, TaskCreatedNotification>(context, logger, mediator)
    {
        
    public override async Threading.Task Handle(TaskCreatedNotification notification,
        CancellationToken cancellationToken)
    {
        try
        {
            Logger.LogInformation($"Try to finished Task (id = {notification.Id}) status...");
            var task = await ContextDb.Tasks.FirstOrDefaultAsync(e => e.Id.Equals(notification.Id));
            task.SetStatus(TaskStatusEnum.Finished);
            await ContextDb.SaveChangesAsync(cancellationToken);
            Logger.LogInformation($"Task (id = {notification.Id}) finished!.");
        }
        catch (Exception ex)
        {
            Logger.LogError($"Error while finished  Task (id = {notification.Id})");
        }
    }
}