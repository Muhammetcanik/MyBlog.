using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Business.Concrete.DTOs
{
    public class CommentDto
    {

        public Guid CommentId { get; set; }

        public string UserName { get; set; } = null!;

        public string Content { get; set; } = null!;

    }
}
