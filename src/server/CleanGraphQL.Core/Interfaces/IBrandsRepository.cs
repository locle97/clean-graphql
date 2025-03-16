using CleanGraphQL.Core.Entities;

namespace CleanGraphQL.Core.Interfaces;

public interface IBrandsRepository
{
    IQueryable<Brand> GetAll();

    Task<Brand> Get(string id);
}
