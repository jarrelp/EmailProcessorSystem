using EmailApi.Application.Common.Models;
using EmailApi.Application.TodoItems.Commands.CreateTodoItem;
using EmailApi.Application.TodoItems.Commands.DeleteTodoItem;
using EmailApi.Application.TodoItems.Commands.UpdateTodoItem;
using EmailApi.Application.TodoItems.Commands.UpdateTodoItemDetail;
using EmailApi.Application.TodoItems.Queries.GetTodoItemsWithPagination;

namespace EmailApi.Web.Controllers;

public class TodoItemsController : ApiControllerBase
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

  [HttpPut("{id}")]
  [ProducesResponseType(StatusCodes.Status204NoContent)]
  [ProducesResponseType(StatusCodes.Status400BadRequest)]
  [ProducesDefaultResponseType]
  public async Task<IActionResult> Update(int id, UpdateTodoItemCommand command)
  {
    if (id != command.Id)
    {
      return BadRequest();
    }

    await Mediator.Send(command);

    return NoContent();
  }

  [HttpPut("[action]")]
  [ProducesResponseType(StatusCodes.Status204NoContent)]
  [ProducesResponseType(StatusCodes.Status400BadRequest)]
  [ProducesDefaultResponseType]
  public async Task<IActionResult> UpdateItemDetails(int id, UpdateTodoItemDetailCommand command)
  {
    if (id != command.Id)
    {
      return BadRequest();
    }

    await Mediator.Send(command);

    return NoContent();
  }

  [HttpDelete("{id}")]
  [ProducesResponseType(StatusCodes.Status204NoContent)]
  [ProducesDefaultResponseType]
  public async Task<IActionResult> Delete(int id)
  {
    await Mediator.Send(new DeleteTodoItemCommand(id));

    return NoContent();
  }
}