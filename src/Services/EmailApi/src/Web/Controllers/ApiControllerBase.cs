using EmailApi.API.Filters;

namespace EmailApi.Web.Controllers;

[ApiController]
[ApiExceptionFilter]
[Route("api/[controller]")]
public abstract class ApiControllerBase : ControllerBase
{
  private ISender? _mediator;

  protected ISender Mediator => _mediator ??= HttpContext.RequestServices.GetRequiredService<ISender>();
}