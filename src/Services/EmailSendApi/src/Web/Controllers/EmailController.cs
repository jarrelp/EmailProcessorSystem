using EmailSendApi.Application.Common.Models;
using EmailSendApi.Application.TodoItems.Commands.CreateTodoItem;
using EmailSendApi.Application.TodoItems.Commands.DeleteTodoItem;
using EmailSendApi.Application.TodoItems.Commands.UpdateTodoItem;
using EmailSendApi.Application.TodoItems.Commands.UpdateTodoItemDetail;
using EmailSendApi.Application.TodoItems.Queries.GetTodoItemsWithPagination;

namespace EmailSendApi.Web.Controllers;

public class EmailController : ApiControllerBase
{
  [HttpGet]
  public async Task<ActionResult<PaginatedList<TodoItemBriefDto>>> GetTodoItemsWithPagination([FromQuery] GetTodoItemsWithPaginationQuery query)
  {
    return await Mediator.Send(query);
  }

  [HttpPost]
  public async Task<ActionResult<int>> Create(CreateTodoItemCommand command)
  {
    return await Mediator.Send(command);
  }

  [HttpPost("process")]
  public async Task<IActionResult> ProcessEmailDataAsync([FromBody] ProcessEmailDataInput input)
  {
    if (!ModelState.IsValid)
    {
      return BadRequest(ModelState);
    }

    await _processEmailDataUseCase.ExecuteAsync(input);

    return Ok();
  }
}