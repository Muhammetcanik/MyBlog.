using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Business.Concrete.DTOs
{
    public class LoginDto
    {
        public string UserName { get; set; } = null!;

        public string Password { get; set; } = null!;

        public bool RememberMe { get; set; }


    }
}
