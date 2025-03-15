using CleanGraphQL.Core.Entities;
using CleanGraphQL.Core.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CleanGraphQL.Application.Queries;

public class GetSwitchesQueryHandler : IRequestHandler<GetSwitchesQuery, IQueryable<Switch>>
{
    private readonly ISwitchesRepository _switchRepository;
    private readonly ILogger<GetSwitchesQueryHandler> _logger;

    public GetSwitchesQueryHandler(ISwitchesRepository switchRepository,
                                   ILogger<GetSwitchesQueryHandler> logger)
    {
        _switchRepository = switchRepository;
        _logger = logger;
    }

    Task<IQueryable<Switch>> IRequestHandler<GetSwitchesQuery, IQueryable<Switch>>.Handle(GetSwitchesQuery request, CancellationToken cancellationToken)
    {
        return Task.FromResult(_switchRepository.GetAll());
    }
}
