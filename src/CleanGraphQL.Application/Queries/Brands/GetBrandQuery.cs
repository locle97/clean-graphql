using CleanGraphQL.Core.Entities;
using MediatR;

namespace CleanGraphQL.Application.Queries;

public class GetBrandQuery: IRequest<Brand>
{
    public required string Id { get; set; }
}
