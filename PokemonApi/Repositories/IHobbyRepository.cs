using HobbyApi.Models;

namespace HobbyApi.Repositories;

public interface IHobbyRepository{
    Task<Hobby> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    Task DeleteAsync(Hobby hobby, CancellationToken cancellationToken);
    Task<List<Hobby>> GetByNameAsync(string name, CancellationToken cancellationToken);
    Task AddAsync(Hobby hobby, CancellationToken cancellationToken);
    Task UpdateAsync(Hobby hobby, CancellationToken cancellationToken);
}