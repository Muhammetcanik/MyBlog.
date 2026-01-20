using Microsoft.AspNetCore.Mvc;
using MyBlog.Business.Abstract;

namespace MyBlog.WebUI.Controllers
{
    public class PostController : Controller
    {
        private readonly IPostService _postService;

        public PostController(IPostService postService)
        {
                _postService = postService;
        }

        //Ipostservice den gelen tüm postları listele. 
        public IActionResult Index()
        {
           var posts = _postService.GetAllPosts();
            return View(posts);
        }


    }
}
