namespace OracleFetchApi.Events;

public record UserIntegrationEvent : BaseEmailIntegrationEvent
{
  public int EmailId { get; init; }
  public string ImageHeader { get; init; } = string.Empty;
  public string Email { get; init; } = string.Empty;
  public string FullName { get; init; } = string.Empty;
  public string UserName { get; init; } = string.Empty;
  public string Password { get; init; } = string.Empty;
  public string Company { get; init; } = string.Empty;
  public string Url { get; init; } = string.Empty;

  public UserIntegrationEvent() : base(0, string.Empty, string.Empty) { }

  public UserIntegrationEvent(int emailQueueId, int emailId, string imageHeader, string email, string fullName, string userName, string password, string company, string url, string emailTo, string subject)
      : base(emailQueueId, emailTo, subject)
  {
    EmailId = emailId;
    ImageHeader = imageHeader;
    Email = email;
    FullName = fullName;
    UserName = userName;
    Password = password;
    Company = company;
    Url = url;
  }
}
