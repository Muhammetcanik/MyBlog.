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
        List<PostDto> GetAllPosts();

        PostDto GetPostById(Guid id);

        bool UpdatePost(PostUpdateDto dto);

        bool AddPost(PostAddDto dto);
    }
}
