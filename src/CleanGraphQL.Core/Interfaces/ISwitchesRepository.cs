using CleanGraphQL.Core.Entities;

namespace CleanGraphQL.Core.Interfaces;

public interface ISwitchesRepository
{
    Task<List<Switch>> GetAll();

    Task<Switch> Get(string id);
}
