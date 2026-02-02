using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Business.Concrete.DTOs
{
   public class PostAddDto
    {

        public string UserName { get; set; }
        public string Title { get; set; }

        public string Content { get; set; }

    }
}
