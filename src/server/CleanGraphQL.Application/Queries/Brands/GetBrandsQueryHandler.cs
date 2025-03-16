using CleanGraphQL.Core.Entities;
using CleanGraphQL.Core.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CleanGraphQL.Application.Queries;

public class GetBrandsQueryHandler : IRequestHandler<GetBrandsQuery, IQueryable<Brand>>
{
    private readonly IBrandsRepository _switchRepository;
    private readonly ILogger<GetBrandsQueryHandler> _logger;

    public GetBrandsQueryHandler(IBrandsRepository switchRepository,
                                   ILogger<GetBrandsQueryHandler> logger)
    {
        _switchRepository = switchRepository;
        _logger = logger;
    }

    Task<IQueryable<Brand>> IRequestHandler<GetBrandsQuery, IQueryable<Brand>>.Handle(GetBrandsQuery request, CancellationToken cancellationToken)
    {
        return Task.FromResult(_switchRepository.GetAll());
    }
}
