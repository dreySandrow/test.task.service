using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Test.Task.Service.Application.Common;
using Test.Task.Service.Domain.Enums;
using Test.Task.Service.Persistence;
using Threading = System.Threading.Tasks;

namespace Test.Task.Service.Application.Tasks.Notifications;

public class TaskCreatedNotificationHandler
    (ApplicationDbContext context, ILogger<TaskCreatedNotificationHandler> logger, IMediator mediator) :
        NotificationHandlerBase<TaskCreatedNotificationHandler, TaskCreatedNotification>(context, logger, mediator)
{
    private static readonly TimeSpan TWO_MINUTES = new TimeSpan(0, 2, 0);

    public override async Threading.Task Handle(TaskCreatedNotification notification,
        CancellationToken cancellationToken)
    {
        try
        {
            Logger.LogInformation($"Try to change Task (id = {notification.Id}) status...");
            var task = await ContextDb.Tasks.FirstOrDefaultAsync(e => e.Id.Equals(notification.Id));
            task.SetStatus(TaskStatusEnum.Running);
            await ContextDb.SaveChangesAsync(cancellationToken);
            Logger.LogInformation($"Status has been changed for Task (id = {notification.Id}).");
        }
        catch (Exception ex)
        {
            Logger.LogError($"Error while changing status for Task (id = {notification.Id})");
            return;
        }

        Logger.LogInformation($"Waiting .... Task (id = {notification.Id})");
        Threading.Task.Delay(TWO_MINUTES);
        
        var finishNotification = new TimeToFinishedTaskNotificaton();
        await Mediator.Publish(new TimeToFinishedTaskNotificaton(), cancellationToken);
    }
}