using EmailApi.Domain.Events;
using Microsoft.Extensions.Logging;

namespace EmailApi.Application.EventHandlers;

public class ProcessEmailEventHandler : INotificationHandler<TodoItemCreatedEvent>
{
    private readonly ILogger<ProcessEmailEventHandler> _logger;

    public ProcessEmailEventHandler(ILogger<ProcessEmailEventHandler> logger)
    {
        _logger = logger;
    }

    public Task Handle(TodoItemCreatedEvent notification, CancellationToken cancellationToken)
    {
        _logger.LogInformation("EmailApi Domain Event: {DomainEvent}", notification.GetType().Name);

        return Task.CompletedTask;
    }
}
