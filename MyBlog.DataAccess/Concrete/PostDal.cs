using MyBlog.Core.DataAccess;
using MyBlog.DataAccess.Abstract;
using MyBlog.DataAccess.Concrete.Contexts;
using MyBlog.Entities.Concrete;


namespace MyBlog.DataAccess.Concrete
{
    public class PostDal : GenericRepository<Post>, IPostDal 
    {
        public PostDal(MyBlogDbContext context) : base(context)
        {
            
        }


    }
}
