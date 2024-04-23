namespace EmailApi.Web.IntegrationEvents.EventHandling;

public class UserEmailIntegrationEventHandler : IIntegrationEventHandler<UserEmailIntegrationEvent>
{
    public UserEmailIntegrationEventHandler()
    {

    }

    public Task Handle(UserEmailIntegrationEvent @event)
    {
        Console.WriteLine($"User Template Attributes:");
        Console.WriteLine($"  ImageHeader: {@event.ImageHeader}");
        Console.WriteLine($"  Email: {@event.Email}");
        Console.WriteLine($"  FullName: {@event.FullName}");
        Console.WriteLine($"  UserName: {@event.UserName}");
        Console.WriteLine($"  Password: {@event.Password}");
        Console.WriteLine($"  Company: {@event.Company}");
        Console.WriteLine($"  Url: {@event.Url}");
        return Task.CompletedTask;
    }
}
