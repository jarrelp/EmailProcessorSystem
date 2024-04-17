namespace OracleFetchApi.IntegrationEvents.Events;

public record ReportEmail(int EmailId, string PortalName, string ReportName, string Url) : IntegrationEvent;