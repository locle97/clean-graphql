using CleanGraphQL.Core.Entities;
using CleanGraphQL.Core.Interfaces;
using MediatR;

namespace CleanGraphQL.Application.Queries;

public class GetBrandQueryHandler : IRequestHandler<GetBrandQuery, Brand>
{
    private readonly IBrandsRepository _switchRepository;

    public GetBrandQueryHandler(IBrandsRepository switchRepository)
    {
        _switchRepository = switchRepository;
    }

    public Task<Brand> Handle(GetBrandQuery request, CancellationToken cancellationToken)
    {
        return _switchRepository.Get(request.Id);
    }
}
