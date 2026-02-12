



namespace MyBlog.Business.Concrete.DTOs
{
    public class PostDto
    {
        public Guid Id { get; set; } 

        public string Title { get; set; } = null!;

        public string Content { get; set; } = null!;

        public DateTime CreatedAt { get; set; }

        public string AuthorFullName { get; set; } = null!;

        

    }
}
