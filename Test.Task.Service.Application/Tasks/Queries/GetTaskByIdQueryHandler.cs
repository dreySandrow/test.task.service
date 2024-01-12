using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Test.Task.Service.Application.Common;
using Test.Task.Service.Application.Models;
using Test.Task.Service.Persistence;

namespace Test.Task.Service.Application.Tasks.Queries;

public sealed class GetTaskByIdQueryHandler
    (ApplicationDbContext applicationDbContext, IMapper mapper, IMediator mediator) : HandlerBase<GetTaskByIdQuery, TaskDto>(
        applicationDbContext, mapper, mediator)
{
    public override async Task<TaskDto> Handle(GetTaskByIdQuery request, CancellationToken cancellationToken)
    {
        var result = await applicationDbContext.Tasks
            .FirstOrDefaultAsync(e => e.Id.Equals(request.Id), cancellationToken);
        return result is null ? null : Mapper.Map<TaskDto>(result);

    }
}