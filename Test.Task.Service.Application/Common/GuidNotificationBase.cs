using MediatR;

namespace Test.Task.Service.Application.Tasks.Notifications;

public abstract class GuidNotificationBase : INotification
{
    public Guid Id { get; set; }
}