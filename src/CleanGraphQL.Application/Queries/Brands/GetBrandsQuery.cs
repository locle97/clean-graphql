using CleanGraphQL.Core.Entities;
using MediatR;

namespace CleanGraphQL.Application.Queries;

public class GetBrandsQuery: IRequest<IEnumerable<Brand>>
{
}

