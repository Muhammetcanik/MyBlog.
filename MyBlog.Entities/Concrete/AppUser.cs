


using Microsoft.AspNetCore.Identity;
using MyBlog.Core.Entities;


namespace MyBlog.Entities.Concrete
{
   public class AppUser : IdentityUser<Guid> , IEntityBase
    {


        // IdentityUser paketini yükledik yorum satırına aldıklarım paketi yüklememiş olsak kullanırdık ancak pakatte hepsi geliyor 
        //ben ayrı bir özellik gelmesini istersem ayrı özellik açarım
        //public Guid Id { get; set; }

        //public string UserName { get; set; }

        //public string Email { get; set; }

        //public string PasswordHash { get; set; }

        //public string FirstName { get; set; }

        //public string LastName { get; set; }

        // Relational  Properties (ilişkisel özellikler)
        // Bir yazarın bir kullanıcısı olur

       
        public DateTime CreatedDate { get; set; }

        public DateTime UpdatedDate { get; set; }

        public DateTime DeletedDate { get; set; }

        public bool IsActive { get; set; }

        public string FirstName { get; set; } = null!; // pakette yok bu ben yeni özellik olarak tanımladım
        public string LastName { get; set; } = null!; // pakette yok bu ben yeni özellik olarak tanımladım
        public Author? Author { get; set; }

        // Bir kullanıcının birden fazla yorumu olabilir.
        public ICollection<Comment> Comments { get; set; } = new List<Comment>();

    }
}
