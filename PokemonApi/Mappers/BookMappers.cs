using BookApi.Dtos;
using BookApi.Infrastructure.Entities;
using BookApi.Models;

namespace BookApi.Mappers;

public static class HobbieMapper {
    public static BookEntity ToEntity(this Book book){
        return new BookEntity{
            Id = book.Id,
            Title = book.Title,
            Author = book.Author,
            PublishedDate = book.PublishedDate
        };
    }

    public static Book ToModel(this BookEntity bookEntity){
        if(bookEntity is null){
            return null;
        }
        return new Book{
            Id = bookEntity.Id,
            Title = bookEntity.Title,
            Author = bookEntity.Author,
            PublishedDate = bookEntity.PublishedDate
        };
    }

    public static BookResponseDto ToDto(this Book book){
        return new BookResponseDto{
            Id = book.Id,
            Title = book.Title,
            Author = book.Author,
            PublishedDate = book.PublishedDate
        };
    }

    public static List<Book> ToModelList(this List<BookEntity> entities)
    {
        return entities?.Select(e => e.ToModel()).ToList() ?? new List<Book>();
    }

    public static List<BookResponseDto> ToDtoList(this List<Book> books)
    {
        return books?.Select(b => b.ToDto()).ToList() ?? new List<BookResponseDto>();
    }
}
