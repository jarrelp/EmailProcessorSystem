namespace OracleFetchApi.IntegrationEvents.Events;

public record LoginEmail(int EmailId, string FullName, string Environment, string Date, string Time) : IntegrationEvent;