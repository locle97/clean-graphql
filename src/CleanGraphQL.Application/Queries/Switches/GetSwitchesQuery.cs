using CleanGraphQL.Core.Entities;
using MediatR;

namespace CleanGraphQL.Application.Queries;

public class GetSwitchesQuery: IRequest<List<Switch>>
{
}

