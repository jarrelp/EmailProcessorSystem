using OracleFetchApi.IntegrationEvents.Events;
using OracleFetchApi.Services;
using OracleFetchApi.ViewModel.EmailTemplates;

namespace OracleFetchApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class IntegrationEventController : ControllerBase
{
    private readonly IEventBus _eventBus;
    private readonly IOracleFetchService _oracleFetchService;

    public IntegrationEventController(
        IEventBus eventBus,
        IOracleFetchService oracleFetchService)
    {
        _eventBus = eventBus;
        _oracleFetchService = oracleFetchService;
    }

    [HttpPost("LoginEmail")]
    public async Task<ActionResult> SendLoginEmailAsync()
    {
        try
        {
            var emailQueues = await _oracleFetchService.GetAllEmailQueuesAsync();

            var integrationEvent = new IntegrationEvent();
            foreach (var emailQueue in emailQueues)
            {

                switch (emailQueue.EmailTemplate)
                {
                    case LoginViewModel loginTemplate:
                        integrationEvent = new LoginEmail(loginTemplate.Id, loginTemplate.FullName, loginTemplate.Environment, loginTemplate.Date, loginTemplate.Time);
                        await _eventBus.PublishAsync(integrationEvent);
                        return Accepted();
                    case Overdue overdueTemplate:
                        integrationEvent = new OverdueEmail(overdueTemplate.Id, overdueTemplate.FullName, overdueTemplate.Email, overdueTemplate.ProductNumber, overdueTemplate.ProductName, overdueTemplate.OrderCode, overdueTemplate.OrderDate, overdueTemplate.OverdueDate);
                        await _eventBus.PublishAsync(integrationEvent);
                        return Accepted();
                    case Report reportTemplate:
                        integrationEvent = new ReportEmail(reportTemplate.Id, reportTemplate.PortalName, reportTemplate.ReportName, reportTemplate.Url);
                        await _eventBus.PublishAsync(integrationEvent);
                        return Accepted();
                    case User userTemplate:
                        integrationEvent = new UserEmail(userTemplate.Id, userTemplate.ImageHeader, userTemplate.Email, userTemplate.FullName, userTemplate.UserName, userTemplate.Password, userTemplate.Company, userTemplate.Url);
                        await _eventBus.PublishAsync(integrationEvent);
                        return Accepted();
                    default:
                        return BadRequest();
                }
            }

            return Accepted();
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }
}
