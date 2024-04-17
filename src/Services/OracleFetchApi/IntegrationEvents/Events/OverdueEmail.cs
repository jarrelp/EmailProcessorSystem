namespace OracleFetchApi.IntegrationEvents.Events;

public record OverdueEmail(int EmailId, string FullName, string Email, string ProductNumber, string ProductName, string OrderCode, string OrderDate, string OverdueDate) : IntegrationEvent;