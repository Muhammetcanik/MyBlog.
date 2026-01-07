

using Microsoft.AspNetCore.Identity;
using MyBlog.Core.Entities;



namespace MyBlog.Entities.Concrete
{
    public class AppRole : IdentityRole<Guid>, IEntityBase
    {

        // IdentityRole paketimin içerisinde aşağıdaki özellikler zaten tanımlı o yüzden yorum komutuna aldım..
        //public Guid Id { get; set; }

        //public string Name { get; set; }

        //public string NormalizedName { get; set; }

        //burdakiler IEntityden gelen özellikler.
       
        public DateTime CreatedDate { get; set; }

        public DateTime UpdatedDate { get; set; }

        public DateTime DeletedDate { get; set; }

        public bool IsActive { get; set; }
    }
}
