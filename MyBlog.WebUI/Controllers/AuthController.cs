using Microsoft.AspNetCore.Mvc;
using MyBlog.Business.Abstract;
using MyBlog.Business.Concrete.DTOs;
using System.Threading.Tasks;

namespace MyBlog.WebUI.Controllers
{
    public class AuthController : Controller
    {
        private readonly IAuthService _authService;


        public AuthController(IAuthService authService)  // dependency injection kullandık constraktor ile private ile birlikte.
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
            var result = await _authService.LoginAsync(loginDto);

            if (result.Succeeded)
                return RedirectToAction("Index", "Post");

            return View(loginDto); // başarısızsa kendi içine bassın


        }



        [HttpGet]
        public IActionResult Register() 
        {
            return View();
        }

        [HttpPost]

        public async Task<IActionResult> Register(RegisterDto registerDto) 
        {

           var result = await _authService.RegisterAsync(registerDto);

            if (result.Succeeded)
            {
                return RedirectToAction(nameof(Login)); 
            }
            return View(registerDto); // eğer başarısızsa kendi içine bassın


        }

        public async Task<IActionResult> Logout()
        {

            await _authService.LogoutAsync();

            return RedirectToAction(nameof(Login)); // şifre başarırsızsa login safyasına atarız.

        }
    }
}
