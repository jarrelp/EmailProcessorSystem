namespace OracleFetchApi.Events;
public record ReportIntegrationEvent : BaseEmailIntegrationEvent
{
  public int EmailId { get; init; }
  public string PortalName { get; init; } = string.Empty;
  public string ReportName { get; init; } = string.Empty;
  public string Url { get; init; } = string.Empty;

  public ReportIntegrationEvent() : base(0, string.Empty, string.Empty) { }

  public ReportIntegrationEvent(int emailQueueId, int emailId, string portalName, string reportName, string url, string emailTo, string subject)
      : base(emailQueueId, emailTo, subject)
  {
    EmailId = emailId;
    PortalName = portalName;
    ReportName = reportName;
    Url = url;
  }
}
