using CleanGraphQL.Core.Entities;

namespace CleanGraphQL.Core.Interfaces;

public interface IBrandsRepository
{
    Task<IEnumerable<Brand>> GetAll();

    Task<Brand?> Get(int id);
}
