using CleanGraphQL.Core.Entities;
using CleanGraphQL.Core.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CleanGraphQL.Application.Queries;

public class GetBrandQueryHandler : IRequestHandler<GetBrandQuery, Brand?>
{
    private readonly IBrandsRepository _brandRepository;
    private readonly ILogger<GetBrandQueryHandler> _logger;

    public GetBrandQueryHandler(IBrandsRepository brandRepository,
                                   ILogger<GetBrandQueryHandler> logger)
    {
        _brandRepository = brandRepository;
        _logger = logger;
    }

    public Task<Brand?> Handle(GetBrandQuery request,
                                            CancellationToken cancellationToken)
    {
        return _brandRepository.Get(request.Id);
    }
}
