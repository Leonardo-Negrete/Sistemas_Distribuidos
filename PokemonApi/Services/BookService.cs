using BookApi.Dtos;
using BookApi.Mappers;
using BookApi.Repositories;

namespace BookApi.Services;

public class BookService : IBookService
{
    private readonly IBookRepository _bookRepository;

    public BookService(IBookRepository bookRepository){
        _bookRepository = bookRepository;
    }

    public async Task<List<BookResponseDto>> GetBookByName(string name, CancellationToken cancellationToken)
    {
        var books = await _bookRepository.GetByNameAsync(name, cancellationToken);
        return books.ToDtoList();
    }
}