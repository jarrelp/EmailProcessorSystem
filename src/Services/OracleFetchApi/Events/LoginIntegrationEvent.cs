namespace OracleFetchApi.Events;

public record LoginIntegrationEvent : BaseEmailIntegrationEvent
{
  public int EmailId { get; init; }
  public string FullName { get; init; } = string.Empty;
  public string Environment { get; init; } = string.Empty;
  public string Date { get; init; } = string.Empty;
  public string Time { get; init; } = string.Empty;

  public LoginIntegrationEvent() : base(0, string.Empty, string.Empty) { }

  public LoginIntegrationEvent(int emailQueueId, int emailId, string fullName, string environment, string date, string time, string emailTo, string subject)
      : base(emailQueueId, emailTo, subject)
  {
    EmailId = emailId;
    FullName = fullName;
    Environment = environment;
    Date = date;
    Time = time;
  }
}
