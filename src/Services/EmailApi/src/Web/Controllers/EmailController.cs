// using EmailApi.Application.Common.Models;
// using EmailApi.Application.TodoItems.Commands.CreateTodoItem;
// using EmailApi.Application.TodoItems.Commands.DeleteTodoItem;
// using EmailApi.Application.TodoItems.Commands.UpdateTodoItem;
// using EmailApi.Application.TodoItems.Commands.UpdateTodoItemDetail;
// using EmailApi.Application.TodoItems.Queries.GetTodoItemsWithPagination;
// using EmailApi.Application.UseCases.ProcessEmailData;

// namespace EmailApi.Web.Controllers;

// public class EmailController : ApiControllerBase
// {
//   [HttpGet]
//   public async Task<ActionResult<PaginatedList<TodoItemBriefDto>>> GetTodoItemsWithPagination([FromQuery] GetTodoItemsWithPaginationQuery query)
//   {
//     return await Mediator.Send(query);
//   }

//   [HttpPost]
//   public async Task<ActionResult<int>> Create(CreateTodoItemCommand command)
//   {
//     return await Mediator.Send(command);
//   }

//   [Topic("pubsub", "oracledata", "deadletters", false)]
//   [HttpPost("process")]

//   public async Task<IActionResult> ProcessEmailDataAsync(IntegrationEvent @event)
//   {
//     if (!ModelState.IsValid)
//     {
//       return BadRequest(ModelState);
//     }

//     await _processEmailDataUseCase.ExecuteAsync(input);

//     return Ok();
//   }
// }