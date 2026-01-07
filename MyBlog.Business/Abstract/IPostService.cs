using MyBlog.Business.Concrete.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Business.Abstract
{
    public interface IPostService
    {
        List<AuthorPostDto> GetAuthorPostDtos(Guid authorId);

    }
}
