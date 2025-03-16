using CleanGraphQL.Application.Queries;
using CleanGraphQL.Core.Entities;
using MediatR;

namespace CleanGraphQL.GraphQL.Queries;

[QueryType]
public class BrandsQueries
{
    public async Task<IQueryable<Brand>> GetBrands([Service] IMediator mediator)
    {
        return await mediator.Send(new GetBrandsQuery());
    }

    public Task<Brand> GetBrand(string id, [Service] IMediator mediator)
    {
        return mediator.Send(new GetBrandQuery { Id = id });
    }

}

