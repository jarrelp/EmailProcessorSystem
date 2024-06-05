namespace OracleFetchApi.Events;

public abstract record BaseEmailIntegrationEvent : IntegrationEvent
{
    public int EmailQueueId { get; init; }
    public string EmailFrom { get; init; } = "test@ecmanage.eu";
    public string EmailTo { get; init; } = null!;
    public string Subject { get; init; } = null!;

    protected BaseEmailIntegrationEvent(int emailQueueId, string emailTo, string subject)
    {
        EmailQueueId = emailQueueId;
        EmailTo = emailTo;
        Subject = subject;
    }
}
