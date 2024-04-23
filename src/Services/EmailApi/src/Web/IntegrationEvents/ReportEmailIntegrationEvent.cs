namespace EmailApi.Web.IntegrationEvents;

public record ReportEmailIntegrationEvent(int EmailId, string PortalName, string ReportName, string Url) : IntegrationEvent;
