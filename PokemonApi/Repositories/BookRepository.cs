using BookApi.Infrastructure.Entities;
using BookApi.Mappers;
using BookApi.Models;
using Microsoft.EntityFrameworkCore;
using PokemonApi.Infrastructure;

namespace BookApi.Repositories;

public class BookRepository : IBookRepository{
    private readonly RelationalDbContext _context;
    public BookRepository(RelationalDbContext context){
        _context = context;
    }
    public async Task<List<Book>> GetByNameAsync(string name, CancellationToken cancellationToken)
    {
        var bookEntities = await _context.Books.AsNoTracking().Where(h => h.Title.Contains(name)) .ToListAsync(cancellationToken);
        return bookEntities.ToModelList();
    }
}