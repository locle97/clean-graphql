using CleanGraphQL.Core.Entities;
using MediatR;

namespace CleanGraphQL.Application.Queries;

public class GetSwitchQuery: IRequest<Switch>
{
    public required string Id { get; set; }
}
