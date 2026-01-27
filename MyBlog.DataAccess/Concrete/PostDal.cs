using MyBlog.Core.DataAccess;
using MyBlog.DataAccess.Abstract;
using MyBlog.DataAccess.Concrete.Contexts;
using MyBlog.Entities.Concrete;
using System.Data.Entity;


namespace MyBlog.DataAccess.Concrete
{
    public class PostDal : GenericRepository<Post>, IPostDal 
    {

        private readonly MyBlogDbContext _context;

        public PostDal(MyBlogDbContext context) : base(context)
        {
            _context = context;
        }

        public List<Post> PostsWithAuthors() 
        {

            return _context.Posts.Include(p => p.Author).ToList();
                    
        
        }

        public Post PostWithAuthor(Guid postId) // post ıd göre yazar bilgisi ile getir
        => _context.Posts.Include(p => p.Author).FirstOrDefault(x => x.Id == postId);
    }
}
