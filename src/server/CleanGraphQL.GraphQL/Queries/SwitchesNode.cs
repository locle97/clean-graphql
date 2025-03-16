using CleanGraphQL.Application.Queries;
using CleanGraphQL.Core.Entities;
using MediatR;

namespace CleanGraphQL.GraphQL.Queries;

[ExtendObjectType<Switch>]
public class SwitchesNode
{
    public async Task<Brand?> GetBrandAsync([Parent] Switch s,
                                            [Service] IMediator mediator,
                                            CancellationToken cancellationToken)
    {
        if (s.BrandId is null)
            return null;

        return await mediator.Send(new GetBrandQuery { Id = s.BrandId },
                                   cancellationToken);
    }
}
