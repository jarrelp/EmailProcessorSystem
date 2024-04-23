namespace EmailApi.Web.IntegrationEvents.EventHandling;

public class LoginEmailIntegrationEventHandler : IIntegrationEventHandler<LoginEmailIntegrationEvent>
{
    public LoginEmailIntegrationEventHandler()
    {

    }

    public Task Handle(LoginEmailIntegrationEvent @event)
    {
        Console.WriteLine($"Login Template Attributes:");
        Console.WriteLine($"  FullName: {@event.FullName}");
        Console.WriteLine($"  Environment: {@event.Environment}");
        Console.WriteLine($"  Date: {@event.Date}");
        Console.WriteLine($"  Time: {@event.Time}");
        return Task.CompletedTask;
    }
}
