using Microsoft.AspNetCore.Mvc;

namespace MyBlog.WebUI.Controllers
{
    public class PostController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }


    }
}
