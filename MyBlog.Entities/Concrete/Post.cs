

using MyBlog.Core.Entities;

namespace MyBlog.Entities.Concrete
{
   public class Post : EntityBase
    {
       

        public Guid AuthorId { get; set; }

        public string Title { get; set; } = null!;

        public string Content { get; set; } = null!;

        //Relational Properties (ilişkisel özellikler)
        public Author? Author { get; set; }
    }
}
