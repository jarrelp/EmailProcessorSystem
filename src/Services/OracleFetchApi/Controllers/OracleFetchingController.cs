namespace OracleFetchApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OracleFetchingController : ControllerBase
{
    private readonly ILogger<OracleFetchingController> _logger;
    private readonly IEmailDataRepository _emailDataRepository;

    public OracleFetchingController(
        ILogger<OracleFetchingController> logger,
        IEmailDataRepository emailDataRepository)
    {
        _logger = logger;
        _emailDataRepository = emailDataRepository;
    }

    [HttpGet("GetAll")]
    public ActionResult GetAll()
    {
        try
        {
            _emailDataRepository.GetAll();
            return StatusCode(200);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error occurred while getting email data");
            return StatusCode(500);
        }
    }

    [HttpGet("GetByEmailQueueId")]
    public ActionResult GetByEmailQueueId(int id)
    {
        try
        {
            _emailDataRepository.GetByEmailQueueId(id);
            return StatusCode(200);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error occurred while getting email data");
            return StatusCode(500);
        }
    }

    [HttpGet("columnNames")]
    public async Task<IActionResult> GetColumnNamesAsync()
    {
        try
        {
            var columnNames = await _emailDataRepository.GetColumnNamesAsync(); // gnt_emailqueue
            return Ok(columnNames);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, $"Internal server error: {ex.Message}");
        }
    }

    [HttpPut("UpdateSent/{id}")]
    public async Task<IActionResult> UpdateSent(int id, [FromQuery] string sentValue)
    {
        try
        {
            _emailDataRepository.SetSent(id, sentValue);
            return Ok();
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }
}
