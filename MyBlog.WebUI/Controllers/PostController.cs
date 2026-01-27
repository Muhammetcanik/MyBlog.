using Microsoft.AspNetCore.Authorization;
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

        public IActionResult Details(Guid id)
        {
            var post = _postService.GetPostById(id); // tek bir post dönmek için post id ile yol alıyorum.
            if (post == null)
                return RedirectToAction("Index");
            return View(post);
        }

        [Authorize(Roles ="author")] // sadece yazar rolündeki kullanıcılar erişebilir ve değişiklik yapabailir
        public IActionResult Edit(Guid id)
        {
            return View();
        }


    }
}
