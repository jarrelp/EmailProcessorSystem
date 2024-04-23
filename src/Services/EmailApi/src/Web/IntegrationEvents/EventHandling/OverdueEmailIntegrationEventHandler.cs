namespace EmailApi.Web.IntegrationEvents.EventHandling;

public class OverdueEmailIntegrationEventHandler : IIntegrationEventHandler<OverdueEmailIntegrationEvent>
{
    public OverdueEmailIntegrationEventHandler()
    {

    }

    public Task Handle(OverdueEmailIntegrationEvent @event)
    {
        Console.WriteLine($"Overdue Template Attributes:");
        Console.WriteLine($"  FullName: {@event.FullName}");
        Console.WriteLine($"  Email: {@event.Email}");
        Console.WriteLine($"  ProductNumber: {@event.ProductNumber}");
        Console.WriteLine($"  ProductName: {@event.ProductName}");
        Console.WriteLine($"  OrderCode: {@event.OrderCode}");
        Console.WriteLine($"  OrderDate: {@event.OrderDate}");
        Console.WriteLine($"  OverdueDate: {@event.OverdueDate}");
        return Task.CompletedTask;
    }
}
