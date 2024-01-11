using AutoMapper;
using MediatR;
using Test.Task.Service.Persistence;

namespace Test.Task.Service.Application.Common;

public abstract class HandlerBase<TC, TM>(ApplicationDbContext applicationDbContext, IMapper mapper) : IRequestHandler<TC, TM>
    where TC : IRequest<TM>
{
    protected ApplicationDbContext ContextDb { get; } = applicationDbContext;
    protected IMapper Mapper { get; } = mapper;

    public abstract Task<TM> Handle(TC request, CancellationToken cancellationToken);
}