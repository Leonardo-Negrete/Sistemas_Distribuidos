using BookApi.Models;

namespace BookApi.Repositories;

public interface IBookRepository{
    Task<List<Book>> GetByNameAsync(string name, CancellationToken cancellationToken);
}