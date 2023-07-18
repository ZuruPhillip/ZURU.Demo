using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZURU.Demo.Domain.Books;

namespace ZURU.Demo.Application.Books.Dto
{
    public class UpdateBookTypeDto
    {
        [Required]
        public Guid id { get; set; }

        [Required]
        public BookType Type { get; set; } = BookType.Undefined;
    }
}
