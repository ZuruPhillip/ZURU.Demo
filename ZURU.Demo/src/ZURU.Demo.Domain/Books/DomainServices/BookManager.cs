using System;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;

namespace ZURU.Demo.Domain.Books.DomainServices
{
    public class BookManager : DomainService, IBookManager
    {
        private readonly IRepository<Book> _repository;

        public BookManager(IRepository<Book> repository)
        {
            _repository = repository;
        }

        //更改书类型
        public async Task<Book> UpdateBookTypeAsync(Guid id, BookType type)
        {
            //获取书名
            var book = await _repository.FindAsync(b => b.Id == id);

            if (book != null)
            {
                book.Type = type;
                return await _repository.UpdateAsync(book);
            }
            else
            {
                throw new Exception("该书不存在");
            }
        }

        //添加书信息
        public async Task<Book> AddBookAsync(string name, BookType bookType, DateTime publishDate, float price)
        {
            var book = await _repository.FindAsync(b => b.Name == name);

            if (book != null)
                return book;

            book = new Book(name, bookType, publishDate, price);

            return await _repository.InsertAsync(book);
        }
    }
}
