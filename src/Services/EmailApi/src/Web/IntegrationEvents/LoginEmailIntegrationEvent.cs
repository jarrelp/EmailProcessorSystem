namespace EmailApi.Web.IntegrationEvents;

public record LoginEmailIntegrationEvent(int EmailId, string FullName, string Environment, string Date, string Time) : IntegrationEvent;
