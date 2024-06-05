namespace OracleFetchApi.Events;

public record OverdueIntegrationEvent : BaseEmailIntegrationEvent
{
  public int EmailId { get; init; }
  public string FullName { get; init; } = string.Empty;
  public string Email { get; init; } = string.Empty;
  public string ProductNumber { get; init; } = string.Empty;
  public string ProductName { get; init; } = string.Empty;
  public string OrderCode { get; init; } = string.Empty;
  public string OrderDate { get; init; } = string.Empty;
  public string OverdueDate { get; init; } = string.Empty;

  public OverdueIntegrationEvent() : base(0, string.Empty, string.Empty) { }

  public OverdueIntegrationEvent(int emailQueueId, int emailId, string fullName, string email, string productNumber, string productName, string orderCode, string orderDate, string overdueDate, string emailTo, string subject)
      : base(emailQueueId, emailTo, subject)
  {
    EmailId = emailId;
    FullName = fullName;
    Email = email;
    ProductNumber = productNumber;
    ProductName = productName;
    OrderCode = orderCode;
    OrderDate = orderDate;
    OverdueDate = overdueDate;
  }
}
