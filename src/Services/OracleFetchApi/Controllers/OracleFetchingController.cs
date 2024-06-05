using System.Xml.Linq;
using AutoMapper;
using OracleFetchApi.Events;
using OracleFetchApi.Model.EmailTemplates;

namespace OracleFetchApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OracleFetchingController : ControllerBase
{
    private readonly ILogger<OracleFetchingController> _logger;
    private readonly IEmailDataRepository _emailDataRepository;
    private readonly IMapper _mapper;

    public OracleFetchingController(
        ILogger<OracleFetchingController> logger,
        IEmailDataRepository emailDataRepository, IMapper mapper)
    {
        _logger = logger;
        _emailDataRepository = emailDataRepository;
        _mapper = mapper;
    }

    [HttpPost("Work")]
    public ActionResult Work()
    {
        try
        {
            _emailDataRepository.GetAllNotPickedUp();
            Console.WriteLine("HelloWorld!");
            return Ok("Hello World!");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error occurred while getting email data");
            return StatusCode(500);
        }
    }

    // [HttpGet]
    // public async Task<ActionResult<List<Events.IntegrationEvent>>> GetEmailQueueItems()
    // {
    //     var emailQueueItems = await _emailDataRepository.GetTopEmailQueueItemsAsync(5);

    //     if (emailQueueItems == null || !emailQueueItems.Any())
    //     {
    //         return NotFound();
    //     }

    //     var integrationEvents = emailQueueItems.Select(emailQueue =>
    //     {
    //         if (emailQueue.XmlData is Login loginData)
    //         {
    //             return _mapper.Map<LoginIntegrationEvent>(emailQueue);
    //         }
    //         else if (emailQueue.XmlData is Overdue overdueData)
    //         {
    //             return _mapper.Map<OverdueIntegrationEvent>(emailQueue);
    //         }
    //         else if (emailQueue.XmlData is Report reportData)
    //         {
    //             return _mapper.Map<ReportIntegrationEvent>(emailQueue);
    //         }
    //         else if (emailQueue.XmlData is User userData)
    //         {
    //             return _mapper.Map<UserIntegrationEvent>(emailQueue);
    //         }
    //         else
    //         {
    //             return null;
    //         }
    //     }).Where(e => e != null).ToList();

    //     return Ok(integrationEvents);
    // }

    [HttpPost("ConvertXmlToUser")]
    public ActionResult<User> ConvertXmlToUser(string xmlData)
    {
        try
        {
            // Parse de XML-string naar een XElement
            XElement element = XElement.Parse(xmlData);

            // Maak een nieuw User-object en vul de eigenschappen in
            User user = new User
            {
                Url = element.Element("url")?.Value,
                UserName = element.Element("username")?.Value,
                Password = element.Element("password")?.Value,
                Email = element.Element("email")?.Value,
                CompanyName = element.Element("companyname")?.Value,
                PersonIdExtern = element.Element("personid_extern")?.Value,
                FullName = element.Element("fullname")?.Value,
                Street = element.Element("street")?.Value,
                PrimaryNumber = element.Element("primarynumber")?.Value,
                AdditionalNumber = element.Element("additionalnumber")?.Value,
                ZipCode = element.Element("zipcode")?.Value,
                City = element.Element("city")?.Value,
                Country = element.Element("country")?.Value
            };

            return user;
        }
        catch (Exception ex)
        {
            // Vang eventuele fouten op bij het parsen van de XML
            return BadRequest($"Error converting XML to User object: {ex.Message}");
        }
    }

    [HttpGet("XmlData")]
    public async Task<ActionResult<List<EmailQueueItem>>> GetXmlData()
    {
        try
        {
            var emailQueueItems = await _emailDataRepository.GetXmlData(2);

            if (emailQueueItems == null || emailQueueItems.Count() == 0)
            {
                return NoContent();
            }

            return Ok(emailQueueItems);
        }
        catch (Exception ex)
        {
            // Log the exception (not shown here)
            return StatusCode(500, "Internal server error");
        }
    }

    [HttpGet("top")]
    public async Task<ActionResult<List<EmailQueueItem>>> GetTopEmailQueueItemsAsync()
    {
        try
        {
            var emailQueueItems = await _emailDataRepository.GetTopEmailQueueItemsAsync(5);

            if (emailQueueItems == null || emailQueueItems.Count() == 0)
            {
                return NoContent();
            }

            return Ok(emailQueueItems);
        }
        catch (Exception ex)
        {
            // Log the exception (not shown here)
            return StatusCode(500, "Internal server error");
        }
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<XmlData>>> GetEmailQueueDataAsync()
    {
        try
        {
            var emailQueueData = await _emailDataRepository.GetTopEmailQueueItemsAsync(5);

            if (emailQueueData == null || emailQueueData.Count() == 0)
            {
                return NoContent();
            }

            var ret = emailQueueData.Select(eq => new EmailQueueItem
            {
                // XmlData = _mapper.Map<XmlData>(eq.XmlData)
            }).ToList();

            return Ok(emailQueueData);
        }
        catch (Exception ex)
        {
            // Log the exception (not shown here)
            return StatusCode(500, "Internal server error");
        }
    }

    [HttpGet("Test")]
        public ActionResult<Login> ConvertXmlToLogin(string xmlData)
        {
            try
            {
                // Parse de XML-string naar een XElement
                XElement element = XElement.Parse(xmlData);

                // Maak een nieuw Login-object en vul de eigenschappen in
                Login login = new Login
                {
                    FullName = element.Element("fullname")?.Value,
                    Environment = element.Element("environment")?.Value,
                    IPAddress = element.Element("ipaddress")?.Value,
                    Date = DateTime.Parse(element.Element("date")?.Value),
                    Time = TimeSpan.Parse(element.Element("time")?.Value)
                };

                return login;
            }
            catch (Exception ex)
            {
                // Vang eventuele fouten op bij het parsen van de XML
                return BadRequest($"Error converting XML to Login object: {ex.Message}");
            }
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

    [HttpGet("GetAllNotPickedUp")]
    public ActionResult GetAllNotPickedUp()
    {
        try
        {
            _emailDataRepository.GetAllNotPickedUp();
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
