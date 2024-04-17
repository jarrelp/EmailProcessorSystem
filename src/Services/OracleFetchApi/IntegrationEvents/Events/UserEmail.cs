namespace OracleFetchApi.IntegrationEvents.Events;

public record UserEmail(int EmailId, string ImageHeader, string Email, string FullName, string UserName, string Password, string Company, string Url) : IntegrationEvent;
