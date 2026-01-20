using MyBlog.Core.DataAccess;
using MyBlog.Entities.Concrete;


namespace MyBlog.DataAccess.Abstract
{
    public interface IPostDal : IGenericRepository<Post>
    {

       List<Post> PostsWithAuthors();   

    }

}
