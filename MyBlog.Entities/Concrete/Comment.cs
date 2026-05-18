

using MyBlog.Core.Entities;

namespace MyBlog.Entities.Concrete
{
    public class Comment : EntityBase
    {
        

        public Guid UserId { get; set; }

        public string Content { get; set; } = null!;

        public Guid PostId { get; set; }

        //RP
        // Bir yorumun bir kullanıcısı olur
        public AppUser? AppUser { get; set; }

        public Post? Post { get; set; }

    }
}
