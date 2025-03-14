using CleanGraphQL.Core.Entities;
using CleanGraphQL.Core.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CleanGraphQL.Application.Queries;

public class GetSwitchesQueryHandler : IRequestHandler<GetSwitchesQuery, List<Switch>>
{
    private readonly ISwitchesRepository _switchRepository;
    private readonly ILogger<GetSwitchesQueryHandler> _logger;

    public GetSwitchesQueryHandler(ISwitchesRepository switchRepository,
                                   ILogger<GetSwitchesQueryHandler> logger)
    {
        _switchRepository = switchRepository;
        _logger = logger;
    }

    public Task<List<Switch>> Handle(GetSwitchesQuery request,
                                            CancellationToken cancellationToken)
    {
        return _switchRepository.GetAll();
    }
}
