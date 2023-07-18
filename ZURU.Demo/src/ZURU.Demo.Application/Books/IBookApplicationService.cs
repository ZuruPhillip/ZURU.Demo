using System.Threading.Tasks;
using ZURU.Demo.Application.Books.Dto;
using ZURU.Demo.Domain.Books;

namespace ZURU.Demo.Application.Books
{
    public interface IBookApplicationService
    {
        Task<Book> AddBook(BookDto book);
        Task<Book> UpdateBookTypeAsync(UpdateBookTypeDto dto);
    }
}