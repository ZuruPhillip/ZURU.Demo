using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;

namespace ZURU.Demo.Domain.Books
{
    public class Book : AuditedAggregateRoot<Guid>
    {
        public string Name { get; set; }
        public BookType Type { get; set; }
        public DateTime PublishDate { get; set;}
        public float Price { get; set; }

        //构造函数
        public Book(string name, BookType type, DateTime publishDate, float price)
        {
            //Check.NotNullOrWhiteSpace(name, nameof(name));

            Name = name;
            Type = type;
            PublishDate = publishDate;
            Price = price;
        }
    }
}
