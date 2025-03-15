using CleanGraphQL.Core.Entities;

namespace CleanGraphQL.Core.Interfaces;

public interface ISwitchesRepository
{
    IQueryable<Switch> GetAll();

    Task<Switch> Get(string id);
}
