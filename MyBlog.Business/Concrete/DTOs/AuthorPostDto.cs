using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Business.Concrete.DTOs
{
   public class AuthorPostDto
    {
        public Guid AuthorId { get; set; }

        public Guid PostId { get; set; }

        public string Title { get; set; } = null!;

        public DateTime CreateDate { get; set; }

        public string Content { get; set; } = null!;



    }
}
