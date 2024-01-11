using MediatR;
using Microsoft.AspNetCore.Mvc;
using Test.Task.Service.Application.Tasks.Commands.Create;
using Test.Task.Service.Application.Tasks.Queries;

namespace Test.Task.Service.Controllers;

[ApiController]
[Route("[controller]")]
public class TaskController(IMediator mediator) : ControllerBase
{
    private IMediator Mediator { get; } = mediator;

    [HttpGet]
    public async Task<IActionResult> CreateTask(CancellationToken cancellationToken)
    {
        var result = await Mediator.Send(new CreateTaskCommand(), cancellationToken);
        return new AcceptedResult(string.Empty,result);
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetTask([FromRoute] Guid id, CancellationToken cancellationToken)
    {
        var request = new GetTaskByIdQuery()
        {
            Id = id
        };

        var result = await Mediator.Send(request, cancellationToken);

        if (result is null)
        {
            return BadRequest($"Task with id = {id} not found.");
        }
        
        return new AcceptedResult(string.Empty, result);
    }
}