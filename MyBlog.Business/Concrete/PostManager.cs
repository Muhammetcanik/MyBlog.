using MyBlog.Business.Abstract;
using MyBlog.Business.Concrete.DTOs;
using MyBlog.DataAccess.Abstract;
using MyBlog.Entities.Concrete;

namespace MyBlog.Business.Concrete
{
    public class PostManager: IPostService
    {

        private readonly  IPostDal _postDal;
        private readonly IAuthService _authService; 

        public PostManager(IPostDal postDal , IAuthService authService)
        {
            _postDal = postDal;
            _authService = authService;
        }

        public bool AddPost(PostAddDto dto)
        {
            return _postDal.Add(new()
            {
                Title = dto.Title,
                Content = dto.Content,
                CreatedDate = DateTime.Now
                


            });




        }

        public List<PostDto> GetAllPosts()
        {
            return _postDal.PostsWithAuthors().Select(x => new PostDto()
            {
                Id = x.Id,
                Title = x.Title,
                Content = x.Content,
                AuthorFullName = x.Author.FullName,
                CreatedAt = x.CreatedDate,


            }).ToList();
        }

        public PostDto GetPostById(Guid id)
        {
            Post post = _postDal.PostWithAuthor(id);

            return new PostDto()
            {
                Id = post.Id,
                Title = post.Title,
                Content = post.Content,
                AuthorFullName = post.Author.FullName,
                CreatedAt = post.CreatedDate,

            };

        }

        public bool UpdatePost(PostUpdateDto dto)
        {
            Post post = _postDal.Get(x => x.Id == dto.Id);

            if (post == null)
                return false;

            post.Title = dto.Title;
            post.Content = dto.Content;
            return _postDal.Update(post);

           
        }
    }
}
