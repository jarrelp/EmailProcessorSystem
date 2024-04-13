using OracleFetchApi.Services;

namespace OracleFetchApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OracleFetchController : ControllerBase
{
  private readonly IOracleFetchService _oracleFetchService;

  public OracleFetchController(IOracleFetchService oracleFetchService)
  {
    _oracleFetchService = oracleFetchService;
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
}
