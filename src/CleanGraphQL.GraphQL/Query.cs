using CleanGraphQL.Application.Queries;
using CleanGraphQL.Core.Entities;
using MediatR;

namespace CleanGraphQL.GraphQL;

public class Query
{
    public Task<Switch> GetSwitch(string id, [Service] IMediator mediator)
    {
        return mediator.Send(new GetSwitchQuery { Id = id });
    }

    public Task<List<Switch>> GetSwitches([Service] IMediator mediator)
    {
        return mediator.Send(new GetSwitchesQuery());
    }
}

