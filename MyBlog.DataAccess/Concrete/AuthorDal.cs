using MyBlog.Core.DataAccess;
using MyBlog.DataAccess.Abstract;
using MyBlog.DataAccess.Concrete.Contexts;
using MyBlog.Entities.Concrete;


namespace MyBlog.DataAccess.Concrete
{
    public class AuthorDal : GenericRepository<Author>, IAuthorDal
    {
        public AuthorDal(MyBlogDbContext context) : base(context)
        {
            
        }
    }
}
