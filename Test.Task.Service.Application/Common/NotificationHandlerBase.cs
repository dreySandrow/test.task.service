using MediatR;
using Microsoft.Extensions.Logging;
using Test.Task.Service.Persistence;

namespace Test.Task.Service.Application.Common;

public abstract class NotificationHandlerBase<TH,TN>(ApplicationDbContext context, ILogger<TH> logger, IMediator mediator) : INotificationHandler<TN>
    where TN : INotification
{
    protected ApplicationDbContext ContextDb { get; } = context;
    protected ILogger<TH> Logger { get; }= logger;
    protected IMediator Mediator { get; }= mediator;

    public abstract System.Threading.Tasks.Task Handle(TN notification, CancellationToken cancellationToken);
}