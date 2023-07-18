using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using ZURU.Demo.Application.Books.Dto;
using ZURU.Demo.Domain;
using ZURU.Demo.Domain.Books;
using ZURU.Demo.Domain.Books.DomainServices;

namespace ZURU.Demo.Application.Books
{
    public class BookApplicationService : DemoAppService, IBookApplicationService
    {
        public readonly IRepository<Book> _repository;
        public readonly IBookManager _bookManager;

        public BookApplicationService(IRepository<Book> repository, IBookManager bookManager)
        {
            _repository = repository;
            _bookManager = bookManager;
        }

        //更新书单信息
        public async Task<Book> UpdateBookTypeAsync(UpdateBookTypeDto dto)
        {
            return await _bookManager.UpdateBookTypeAsync(dto.id, dto.Type);
        }

        //添加书清单数据
        public async Task<Book> AddBook(BookDto book)
        {
            return await _bookManager.AddBookAsync(book.Name, book.Type, book.PublishDate, book.Price);
        }
    }
}
