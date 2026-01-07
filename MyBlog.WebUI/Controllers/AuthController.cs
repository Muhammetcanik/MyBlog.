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
    }
}
