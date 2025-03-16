using CleanGraphQL.Application.Queries;
using CleanGraphQL.Core.Entities;
using MediatR;

namespace CleanGraphQL.GraphQL.Queries;

[QueryType]
public class SwitchesQueries
{
    [UsePaging]
    [UseFiltering]
    public async Task<IQueryable<Switch>> GetSwitches([Service] IMediator mediator)
    {
        return await mediator.Send(new GetSwitchesQuery());
    }

    public Task<Switch> GetSwitch(string id, [Service] IMediator mediator)
    {
        return mediator.Send(new GetSwitchQuery { Id = id });
    }

}

