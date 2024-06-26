using FakeOracleFetchApi.IntegrationEvents.Events;
using FakeOracleFetchApi.Services;

namespace FakeOracleFetchApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OracleFetchController : ControllerBase
{
  private readonly IOracleFetchService _oracleFetchService;

  private readonly IEventBus _eventBus;

  public OracleFetchController(
    IOracleFetchService oracleFetchService,
    IEventBus eventBus)
  {
    _oracleFetchService = oracleFetchService;
    _eventBus = eventBus;
  }

  [HttpGet]
  public async Task<IActionResult> GetAllEmailQueues()
  {
    try
    {
      var emailQueues = await _oracleFetchService.GetAllEmailQueuesAsync();
      return Ok(emailQueues);
    }
    catch (Exception ex)
    {
      return StatusCode(500, $"Internal server error: {ex.Message}");
    }
  }

  [HttpGet("{id}")]
  public async Task<IActionResult> GetEmailQueueById(int id)
  {
    try
    {
      var emailQueue = await _oracleFetchService.GetEmailQueueByIdAsync(id);
      if (emailQueue == null)
      {
        return NotFound();
      }
      return Ok(emailQueue);
    }
    catch (Exception ex)
    {
      return StatusCode(500, $"Internal server error: {ex.Message}");
    }
  }

  [HttpPost]
  public async Task<IActionResult> AddEmailQueue(EmailQueue emailQueue)
  {
    try
    {
      await _oracleFetchService.AddEmailQueueAsync(emailQueue);

      var emailTemplate = MapToRecord(emailQueue.EmailTemplate);

      await _eventBus.PublishAsync(emailTemplate);

      return CreatedAtAction(nameof(GetEmailQueueById), new { id = emailQueue.EmailQueueId }, emailQueue);
    }
    catch (Exception ex)
    {
      return StatusCode(500, $"Internal server error: {ex.Message}");
    }
  }

  [HttpPut("{id}")]
  public async Task<IActionResult> UpdateEmailQueue(int id, EmailQueue emailQueue)
  {
    try
    {
      if (id != emailQueue.EmailQueueId)
      {
        return BadRequest("ID mismatch");
      }
      await _oracleFetchService.UpdateEmailQueueAsync(emailQueue);
      return NoContent();
    }
    catch (Exception ex)
    {
      return StatusCode(500, $"Internal server error: {ex.Message}");
    }
  }

  [HttpDelete("{id}")]
  public async Task<IActionResult> DeleteEmailQueue(int id)
  {
    try
    {
      var emailQueueToDelete = await _oracleFetchService.GetEmailQueueByIdAsync(id);
      if (emailQueueToDelete == null)
      {
        return NotFound();
      }
      await _oracleFetchService.DeleteEmailQueueAsync(id);
      return NoContent();
    }
    catch (Exception ex)
    {
      return StatusCode(500, $"Internal server error: {ex.Message}");
    }
  }

  private IntegrationEvent MapToRecord(EmailTemplate emailTemplate)
  {
    switch (emailTemplate)
    {
      case Login loginTemplate:
        return new LoginEmail(loginTemplate.Id, loginTemplate.FullName, loginTemplate.Environment, loginTemplate.Date, loginTemplate.Time);
      case Overdue overdueTemplate:
        return new OverdueEmail(overdueTemplate.Id, overdueTemplate.FullName, overdueTemplate.Email, overdueTemplate.ProductNumber, overdueTemplate.ProductName, overdueTemplate.OrderCode, overdueTemplate.OrderDate, overdueTemplate.OverdueDate);
      case Report reportTemplate:
        return new ReportEmail(reportTemplate.Id, reportTemplate.PortalName, reportTemplate.ReportName, reportTemplate.Url);
      case User userTemplate:
        return new UserEmail(userTemplate.Id, userTemplate.ImageHeader, userTemplate.Email, userTemplate.FullName, userTemplate.UserName, userTemplate.Password, userTemplate.Company, userTemplate.Url);
      default:
        return null;
    }
  }
}
