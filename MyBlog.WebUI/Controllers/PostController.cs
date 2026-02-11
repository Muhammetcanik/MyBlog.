using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyBlog.Business.Abstract;
using MyBlog.Business.Concrete.DTOs;

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
            var post = _postService.GetPostById(id);
            return View(post);
        }

        [Authorize(Roles = "author")]
        [HttpPost]
        public IActionResult Edit(PostUpdateDto postUpdate)
        {
            bool response = _postService.UpdatePost(postUpdate);
            if (!response)
                return View(postUpdate); // güncelleme başarısızsa aynı sayfada kal

            return RedirectToAction(nameof(Index)); // güncelleme başarılıysa liste sayfasına yönlendir
        }

        [Authorize(Roles = "author")]
        public IActionResult Create()
        {

            return View();
        
        }

        [Authorize(Roles = "author")]
        [HttpPost]
        public IActionResult Create(PostAddDto postAdd)
        => _postService.AddPost(postAdd) ? RedirectToAction("Index") : View(postAdd); // ekleme başarılıysa liste sayfasına yönlendir, başarısızsa aynı sayfada kal



        // 1 olarak controllerde create açarız önce getını sonra postunu , sonra DTO da class oluştururuz
        //PostAddDto gibi ordan kullanıcının görmek istediklerini gireriz
        // post içerigini doldururuz ve bir görünüm oluştutuz.
        //IpostService add yaparız interfaceye sonra managerda implemente ederiz. Abstract daha sonra concrete yaparız




    }
}
