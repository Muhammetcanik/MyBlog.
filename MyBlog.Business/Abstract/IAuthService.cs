

using Microsoft.AspNetCore.Identity;
using MyBlog.Business.Concrete.DTOs;
using MyBlog.Entities.Concrete;

namespace MyBlog.Business.Abstract
{
  public interface IAuthService
    {
        //hepsini async yaparız metotların async çalıştığını yani bekleme süresinin olmaması gerektirdğini belirtiriz
        //bunları burda değiştirdiğimizde authmanager kısmındada isimleri değiştiririz önemli.
        Task<IdentityResult> RegisterAsync(RegisterDto registerDto, AuthorAddDto? authorAddDto=null);
        Task<SignInResult> LoginAsync(LoginDto loginDto);

        Task LogoutAsync();


        AppUser GetUser(string userName);



    }
}
