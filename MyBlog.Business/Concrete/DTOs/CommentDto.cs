using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Business.Concrete.DTOs
{
    public class CommentDto
    {
        public Guid UserId { get; set; }
        public Guid CommentId { get; set; }

        public Guid PostId { get; set; }

        

        public string Content { get; set; } = null!;

    }
}
