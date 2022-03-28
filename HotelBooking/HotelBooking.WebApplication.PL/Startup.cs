using AutoMapper;
using HotelBooking.BLL.Services;
using HotelBooking.BLL.Services.IServices;
using HotelBooking.DAL.Models;
using HotelBooking.DAL.Repositories;
using HotelBooking.DAL.Repositories.IRepositories;
using HotelBooking.WebApplication.PL.Automapper;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace HotelBooking.WebApplication.PL
{
    public class Startup
    {
        private IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            var connectionString = _configuration.GetValue<string>("connectionString");
            services.AddControllersWithViews();
            services.AddDbContext<HotelBookingDbContext>(x => x.UseSqlServer(connectionString));
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).
                AddCookie(options => { options.LoginPath = "/User/Login"; });

            services.AddSingleton(new MapperConfiguration(x => x.AddProfile(new AutomapperProfile())).CreateMapper());

            services.AddScoped<IUserRepository>(
                x => new UserRepository(
                    x.GetService<HotelBookingDbContext>(),
                    x.GetService<IMapper>()));
            services.AddScoped<IUserService>(
                x => new UserService(
                    x.GetService<IUserRepository>(),
                    x.GetService<IMapper>()));

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseStaticFiles();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}");
            });
        }
    }
}