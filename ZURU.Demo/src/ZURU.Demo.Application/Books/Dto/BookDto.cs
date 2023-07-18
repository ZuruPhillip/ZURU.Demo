using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using ZURU.Demo.Domain.Books;

namespace ZURU.Demo.Application.Books.Dto
{
    public class BookDto : AuditedEntityDto<Guid>
    {
        [Required]
        public string Name { get; set; }

        public BookType Type { get; set; }

        public DateTime PublishDate { get; set; }

        public float Price { get; set; }
    }
}
