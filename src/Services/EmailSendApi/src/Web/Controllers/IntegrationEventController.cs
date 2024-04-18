namespace EmailSendApi.Web.Controllers;

public class IntegrationEventController : ApiControllerBase
{
    private const string DAPR_PUBSUB_NAME = "eshopondapr-pubsub";

    [HttpPost("OrderStatusChangedToSubmitted")]
    [Topic(DAPR_PUBSUB_NAME, nameof(LoginEmail))]
    public Task HandleAsync(
        OrderStatusChangedToSubmittedIntegrationEvent @event,
        [FromServices] OrderStatusChangedToSubmittedIntegrationEventHandler handler)
        => handler.Handle(@event);
}
