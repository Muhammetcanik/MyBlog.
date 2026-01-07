using MyBlog.Core.DataAccess;
using MyBlog.DataAccess.Abstract;
using MyBlog.DataAccess.Concrete.Contexts;
using MyBlog.Entities.Concrete;


namespace MyBlog.DataAccess.Concrete
{
    public class CommentDal : GenericRepository<Comment>, IConmmentDal
    {
        public CommentDal(MyBlogDbContext context) : base(context)
        {
        }
    }
}
