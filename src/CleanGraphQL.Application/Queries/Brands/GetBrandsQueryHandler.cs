using CleanGraphQL.Core.Entities;
using CleanGraphQL.Core.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CleanGraphQL.Application.Queries;

public class GetBrandsQueryHandler : IRequestHandler<GetBrandsQuery, IEnumerable<Brand>>
{
    private readonly IBrandsRepository _brandRepository;
    private readonly ILogger<GetBrandsQueryHandler> _logger;

    public GetBrandsQueryHandler(IBrandsRepository brandRepository,
                                   ILogger<GetBrandsQueryHandler> logger)
    {
        _brandRepository = brandRepository;
        _logger = logger;
    }

    public Task<IEnumerable<Brand>> Handle(GetBrandsQuery request,
                                            CancellationToken cancellationToken)
    {
        return _brandRepository.GetAll();
    }
}
