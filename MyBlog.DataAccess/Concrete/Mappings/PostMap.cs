using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyBlog.Entities.Concrete;


namespace MyBlog.DataAccess.Concrete.Mappings
{
  public  class PostMap : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder.HasKey(x => x.Id);
        }
    }
}
