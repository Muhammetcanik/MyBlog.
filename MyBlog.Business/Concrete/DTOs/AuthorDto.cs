using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Business.Concrete.DTOs
{
    public class AuthorDto
    {
        public Guid Id { get; set; }

        public string FullName { get; set; } = null!;

        public string UserName { get; set; } = null!;

    }
}
