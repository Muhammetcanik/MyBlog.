using Microsoft.EntityFrameworkCore;
using MyBlog.Business.Abstract;
using MyBlog.DataAccess.Concrete.Contexts;
using MyBlog.Entities.Concrete;

namespace MyBlog.WebUI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();


            //soru iþareti boþ gelebilir anlamýna gelir
            string? connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

            //container
            builder.Services.AddScoped<IAuthService,AuthManager>();

            builder.Services.AddDbContext<MyBlogDbContext>(x => x.UseSqlServer(connectionString));

            //parolayý kendimize uyarlýyoruz
            builder.Services.AddIdentity<AppUser, AppRole>(x =>
            {
                x.Password.RequireDigit = false; // parola içerisinde rakam bulunma zorunluluðunu kaldýrdýk.
                x.Password.RequireLowercase = false; // en az bir tane küçük harf bulunma zorunluluðunu kaldýrdýk
                x.Password.RequireUppercase = false; // en az bir tane büyük harf zorunluluðunu kaldýrdýk
                x.Password.RequireNonAlphanumeric = false; // özel karakter zorunluluðunu kaldýrdýk
                x.Password.RequiredLength = 1; // þifenin uzunluðu minimum 1 karakter olabilir.
                x.Password.RequireUppercase = false;


            }
            ).AddEntityFrameworkStores<MyBlogDbContext>(); //sað týklayýp add reference to myblog data base yapýldý
            //data base baðlamak için

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication(); // kimlik
            app.UseAuthorization(); // yetki

           
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Auth}/{action=Register}/{id?}"); // Authcontrolden baþlasýn register aksiyonu ile devam eder yolu bu þekilde belirledik.

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                  name: "areas",
                  pattern: "{area:exists}/{controller=Account}/{action=Register}/{id?}"
                );
            });

            app.Run();
        }
    }
}