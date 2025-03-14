using CleanGraphQL.Core.Entities;
using CleanGraphQL.Core.Interfaces;

namespace CleanGraphQL.Infrastructure.Presistence;

public class BrandsRepository : IBrandsRepository
{
    private readonly IEnumerable<Brand> BrandCollection = new List<Brand>
        {
            new Brand {
                Id = 1,
                Name = "Cherry"
            },
            new Brand {
                Id = 2,
                Name = "Gateron"
            }
        };

    Task<Brand?> IBrandsRepository.Get(int id)
    {
        return Task.FromResult<Brand?>(BrandCollection.FirstOrDefault(t => t.Id == id));
    }

    Task<IEnumerable<Brand>> IBrandsRepository.GetAll()
    {
        return Task.FromResult<IEnumerable<Brand>>(BrandCollection);
    }
}

