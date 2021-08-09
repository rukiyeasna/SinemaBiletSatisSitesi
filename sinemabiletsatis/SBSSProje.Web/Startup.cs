using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SBSSProje.Business.Concrete;
using SBSSProje.Business.Interfaces;
using SBSSProje.DataAccess.Concrete.EntityFrameworkCore.Contexts;
using SBSSProje.DataAccess.Concrete.EntityFrameworkCore.Repositories;
using SBSSProje.DataAccess.Interfaces;
using SBSSProje.Entities.Concrete;
using System;

namespace SBSSProje.Web
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {


            services.AddScoped<IMovieService, MovieManager>();
            services.AddScoped<IMovieDal, EfMovieRepository>();
            services.AddScoped<IBranchService, BranchManager>();
            services.AddScoped<IBranchDal, EfBranchRepository>();
            services.AddScoped<IHallService, HallManager>();
            services.AddScoped<IHallDal, EfHallRepository>();
            services.AddScoped<IMBHService, MBHManager>();
            services.AddScoped<IMBHDal, EfMBHRepository>();
            services.AddScoped<ISalesService, SalesManager>();
            services.AddScoped<ISalesDal, EfSalesRepository>();



            services.AddDbContext<SbssContext>();
            services.AddIdentity<AppUser, AppRole>(opt =>
            {
                opt.Password.RequireDigit = false;
                opt.Password.RequireUppercase = false;
                opt.Password.RequiredLength = 1;
                opt.Password.RequireLowercase = false;
                opt.Password.RequireNonAlphanumeric = false;
            }).AddEntityFrameworkStores<SbssContext>();

            services.ConfigureApplicationCookie(opt => {
                opt.Cookie.Name = "sinemabilet";//name
                opt.Cookie.SameSite = Microsoft.AspNetCore.Http.SameSiteMode.Strict;//baþka web sayfalarý ile paylaþýlmasýný istemiyoruz
                opt.Cookie.HttpOnly = true;//ilgili kullanýcý bir þey yazark ulaþmasýný istemiyoruz
                opt.ExpireTimeSpan = TimeSpan.FromDays(20);//ne kadar sire ayakta kalacaðýný belirliyoruz
                opt.Cookie.SecurePolicy = Microsoft.AspNetCore.Http.CookieSecurePolicy.SameAsRequest;
                opt.LoginPath = "/Home/Index";
            });

            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env,UserManager<AppUser> userManager, RoleManager<AppRole> roleManager)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            IdentityInitializer.SeedData(userManager,roleManager).Wait();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "areas",
                    pattern: "{area}/{controller=Home}/{action=Index}/{id?}"
                    );


                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}"
                    );

            });
        }
    }
}
