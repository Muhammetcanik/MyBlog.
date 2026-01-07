using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyBlog.Entities.Concrete;


namespace MyBlog.DataAccess.Concrete.Mappings
{
   public class AppUserMap : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.HasMany(x => x.Comments)
                .WithOne(x =>x.AppUser)
                .HasForeignKey(x => x.UserId);

            builder.HasOne(x => x.Author)
                .WithOne(x => x.AppUser)
                .HasForeignKey<Author>(x => x.Id);
        }
    }
}
