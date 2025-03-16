using CleanGraphQL.Core.Entities;
using CleanGraphQL.Core.Interfaces;
using MediatR;

namespace CleanGraphQL.Application.Queries;

public class GetSwitchQueryHandler : IRequestHandler<GetSwitchQuery, Switch>
{
    private readonly ISwitchesRepository _switchRepository;

    public GetSwitchQueryHandler(ISwitchesRepository switchRepository)
    {
        _switchRepository = switchRepository;
    }

    public Task<Switch> Handle(GetSwitchQuery request, CancellationToken cancellationToken)
    {
        return _switchRepository.Get(request.Id);
    }
}
