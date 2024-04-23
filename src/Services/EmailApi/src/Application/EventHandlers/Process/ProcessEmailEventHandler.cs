using EmailApi.Domain.Events;
using Microsoft.Extensions.Logging;

namespace EmailApi.Application.EventHandlers.Process;

public class ProcessLoginEmailEventHandler : INotificationHandler<TodoItemCreatedEvent>
{
    private readonly ILogger<ProcessLoginEmailEventHandler> _logger;

    public ProcessLoginEmailEventHandler(ILogger<ProcessLoginEmailEventHandler> logger)
    {
        _logger = logger;
    }

    public Task Handle(TodoItemCreatedEvent notification, CancellationToken cancellationToken)
    {
        _logger.LogInformation("EmailApi Domain Event: {DomainEvent}", notification.GetType().Name);

        return Task.CompletedTask;
    }
}
