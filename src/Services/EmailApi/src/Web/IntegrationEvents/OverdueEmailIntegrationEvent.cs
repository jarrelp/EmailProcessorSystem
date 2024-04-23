namespace EmailApi.Web.IntegrationEvents;

public record OverdueEmailIntegrationEvent(int EmailId, string FullName, string Email, string ProductNumber, string ProductName, string OrderCode, string OrderDate, string OverdueDate) : IntegrationEvent;
