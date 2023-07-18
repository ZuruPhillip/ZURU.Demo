using System;
using System.Threading.Tasks;

namespace ZURU.Demo.Domain.Books.DomainServices
{
    public interface IBookManager
    {
        Task<Book> AddBookAsync(string name, BookType bookType, DateTime publishDate, float price);
        Task<Book> UpdateBookTypeAsync(Guid id, BookType type);
    }
}