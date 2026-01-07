using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyBlog.Entities.Concrete;


namespace MyBlog.DataAccess.Concrete.Mappings
{
    public class AuthorMap : IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.FullName).IsRequired();

            builder.HasMany(x => x.Posts).WithOne(x => x.Author).HasForeignKey(x => x.AuthorId);
        }
    }
}
