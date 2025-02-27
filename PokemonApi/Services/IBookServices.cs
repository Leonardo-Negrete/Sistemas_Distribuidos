using System.ServiceModel;
using BookApi.Dtos;

namespace BookApi.Services;

[ServiceContract(Name = "BookService", Namespace ="http://book-api/book-service")]

public interface IBookService{
    [OperationContract]
    Task<List<BookResponseDto>> GetBookByName(string name, CancellationToken cancellationToken);
}