using OracleFetchApi.IntegrationEvents.Events;

namespace OracleFetchApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class IntegrationEventController : ControllerBase
{
    private readonly IEventBus _eventBus;

    public IntegrationEventController(
        IEventBus eventBus)
    {
        _eventBus = eventBus;
    }

    [HttpPost("LoginEmail")]
    public async Task<ActionResult> SendLoginEmailAsync(LoginEmail loginEmail)
    {
        await _eventBus.PublishAsync(loginEmail);

        return Accepted();
    }
}
