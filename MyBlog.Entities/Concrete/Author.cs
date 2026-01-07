

using MyBlog.Core.Entities;

namespace MyBlog.Entities.Concrete
{
   public class Author : EntityBase
    {
       

        public string FullName { get; set; } = null!;

        public DateTime BirthDate { get; set; }

        //Navigation Properties
        // Bir yazarın bir kullanıcısı olur

        public AppUser? AppUser { get; set; }

        public ICollection<Post> Posts { get; set; } = new List<Post>();

    }
}
