using Microsoft.AspNetCore.Mvc;
using MyBlog.Business.Abstract;
using MyBlog.Business.Concrete.DTOs;
using System.Threading.Tasks;

namespace MyBlog.WebUI.Areas.Author.Controllers
{
    [Area("Author")]
    public class AccountController : Controller
    {

        readonly private IAuthService _authService;

        public AccountController(IAuthService authService)
        {
            _authService = authService;
        }

        public IActionResult Login()
        {
            return View();

        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            var result = await _authService.LoginAsync(loginDto); // LoginAsync metodu async olduğu için beklememiz gerekiyor. 
            return result.Succeeded ? RedirectToAction("Index", "Create") : View(loginDto); // login başarılıysa anasayfaya yönlendir, başarısızsa aynı sayfada kal ve loginDto'yu geri gönder.
            return View();

        }

        public IActionResult Register()
        {
            return View();

        }

        //[HttpPost]
        //public async Task<IActionResult> Register(RegisterDto registerDto, AuthorAddDto authorAddDto)
        //{
        //    var result = await _authService.RegisterAsync(registerDto, authorAddDto);
        //    if (result.Succeeded)
        //        return RedirectToAction("Login");

        //    return View(registerDto);
        //}

        [HttpPost]
        public async Task<IActionResult> Register(RegisterDto registerDto, DateTime BirthDate)  // PascalCase ile aynı
        {
            var authorDto = new AuthorAddDto
            {
                BirthDate = BirthDate
            };


            if ((await _authService.RegisterAsync(registerDto, authorDto)).Succeeded)
                return RedirectToAction("Login");

            return View(registerDto);
        }




    }
}
