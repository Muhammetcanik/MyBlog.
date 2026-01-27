using MyBlog.Business.Abstract;
using MyBlog.Business.Concrete.DTOs;
using MyBlog.DataAccess.Abstract;
using MyBlog.Entities.Concrete;

namespace MyBlog.Business.Concrete
{
    public class PostManager: IPostService
    {

        private readonly  IPostDal _postDal;

        public PostManager(IPostDal postDal)
        {
            _postDal = postDal;
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
    }
}
