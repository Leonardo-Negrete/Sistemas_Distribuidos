using HobbieApi.Models;

namespace HobbieApi.Repositories;

public interface IHobbieRepository{
    Task<Hobbie> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    Task DeleteAsync(Hobbie hobbie, CancellationToken cancellationToken);
    Task<List<Hobbie>> GetByNameAsync(string name, CancellationToken cancellationToken);
    Task AddAsync(Hobbie hobbie, CancellationToken cancellationToken);
    Task UpdateAsync(Hobbie hobbie, CancellationToken cancellationToken);
}