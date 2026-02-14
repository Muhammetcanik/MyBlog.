
//using Microsoft.AspNetCore.Identity;
//using MyBlog.Business.Abstract;
//using MyBlog.Business.Concrete.DTOs;
//using MyBlog.Entities.Concrete;
//using System.Threading.Tasks;
//using System.Xml.Linq;

using Microsoft.AspNetCore.Identity;
using MyBlog.Business.Abstract;
using MyBlog.Business.Concrete.DTOs;
using MyBlog.DataAccess.Abstract;  // ✅ IAuthorDal için
using MyBlog.Entities.Concrete;
using Microsoft.EntityFrameworkCore;  // ✅ Include için

public class AuthManager : IAuthService
{
    //depenndency ınjection
    private readonly UserManager<AppUser> _userManager;
    private readonly RoleManager<AppRole> _roleManager;
    private readonly SignInManager<AppUser> _signInManager; // giriş için bunların hepsi paketten geliyor.
    private readonly IAuthorDal _authorDal;

    public AuthManager(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager, SignInManager<AppUser> signInManager, IAuthorDal authorDal)
    {
        _userManager = userManager;
        _roleManager = roleManager;
        _signInManager = signInManager;
        _authorDal = authorDal;
        _authorDal = authorDal;
    }

    //üyelik ekleme
    //IdentityResult yapılan işlemin sonucunu tutar. Result.Secceeded ile başarılı mı başarısız mı kontrol edebiliriz.
    public async Task<IdentityResult> RegisterAsync(RegisterDto registerDto , AuthorAddDto? authorAddDto = null)
    {

        var appUser = new AppUser
        {

            UserName = registerDto.UserName,
            Email = registerDto.Email,
            FirstName = registerDto.FirstName,
            LastName = registerDto.LastName,
            PhoneNumber = registerDto.PhoneNumber,
            CreatedDate = DateTime.Now,
            IsActive = true

        };


        //CreateAsync metodu, kullanıcıyı veritabanına eklemeyi dener ve sonucu bir IdentityResult içinde döndürür.
        IdentityResult result = await _userManager.CreateAsync(appUser); // bunu en altta döneriz.

        if (result.Succeeded)
        {

           await  _userManager.AddPasswordAsync(appUser,registerDto.Password);
            
        }

        if (authorAddDto is not null) 
        {

            var author = new Author
            {
                Id = appUser.Id,
                BirthDate = authorAddDto.BirthDate,
                FullName = $"{registerDto.FirstName} - {registerDto.LastName}",

                CreatedDate = DateTime.Now,
                IsActive = true,
            };
            _authorDal.Add(author);

            result = await AddRoleToUser(appUser, "author");

        }

        else
        {
            result = await AddRoleToUser(appUser,"user");
        }

        return result;

    }


    //giriş yapma
    public async Task<SignInResult> LoginAsync(LoginDto loginDto)
    {
        //sisnginresult döndüğümüz için en son kesinlikle return ile döndürmeliyiz
        var result = await _signInManager.PasswordSignInAsync(loginDto.UserName, loginDto.Password, loginDto.RememberMe, false);

        return result;
    }

    public async Task LogoutAsync()
    {
        await _signInManager.SignOutAsync();
    }

    //roll ekleme metodumuz.
    private async Task<IdentityResult> AddRoleToUser(AppUser appUser,string role)
    {
        var getRole = _roleManager.Roles.FirstOrDefault(x => x.Name == role);
        AppRole appRole;
       
        if (getRole is null)
        {
          appRole = new AppRole()
            {
                IsActive = true,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                NormalizedName = role.ToUpper(),
                Name = role,

            };
            await _roleManager.CreateAsync(appRole);
        }

        return await _userManager.AddToRoleAsync(appUser, role);
    }

    public AppUser GetUser(string userName)
    => _userManager.Users.FirstOrDefault(x => x.UserName == userName);
}