namespace EmailApi.Web.IntegrationEvents.EventHandling;

public class ReportEmailIntegrationEventHandler : IIntegrationEventHandler<ReportEmailIntegrationEvent>
{
    public ReportEmailIntegrationEventHandler()
    {

    }

    public Task Handle(ReportEmailIntegrationEvent @event)
    {
        Console.WriteLine($"Report Template Attributes:");
        Console.WriteLine($"  PortalName: {@event.PortalName}");
        Console.WriteLine($"  ReportName: {@event.ReportName}");
        Console.WriteLine($"  Url: {@event.Url}");
        return Task.CompletedTask;
    }
}
