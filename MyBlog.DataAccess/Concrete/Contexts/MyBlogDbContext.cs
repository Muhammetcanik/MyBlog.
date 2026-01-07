using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MyBlog.Entities.Concrete;
using System.Reflection;


namespace MyBlog.DataAccess.Concrete.Contexts
{
    public class MyBlogDbContext : IdentityDbContext<AppUser, AppRole, Guid>
    {
        public MyBlogDbContext(DbContextOptions<MyBlogDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            
            // Burada tüm mapping dosyalarını otomatik olarak uygulayabiliriz
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(builder);
        }

        public DbSet<Author> Authors { get; set; }
        public DbSet<Comment> Comments { get; set; }

        public DbSet<Post> Posts { get; set; }
    }
}
