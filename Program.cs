using ETickets.Data;
using ETickets.Models;
using ETickets.Repository;
using ETickets.Repository.IRepository;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Stripe;
using System.Data.Common;

namespace ETickets
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.Configure<StripeSettings>(builder.Configuration.GetSection("Stripe"));
            StripeConfiguration.ApiKey = builder.Configuration["Stripe:SecretKey"];
            //Identity Service
            builder.Services.AddIdentity<ApplicationUser,IdentityRole>().
            AddEntityFrameworkStores<ApplicationDbContext>();
            //CONNECTION SERVICE DATABASE "DBTickets"
            builder.Services.AddDbContext<ApplicationDbContext>
            (options => options.UseSqlServer
            (builder.Configuration.GetConnectionString
            ("DefaultConnection")));
            builder.Services.AddScoped<IActorRepository,ActorRepository>();
            builder.Services.AddScoped<IActorMovieRepository , ActorMovieRepository>();
            builder.Services.AddScoped<IMovieRepository,MovieRepository>();
            builder.Services.AddScoped<ICinemaRepository,CinemaRepository>();
            builder.Services.AddScoped<ICategoryRepository,CategoryRepository>();
            builder.Services.AddScoped<ICartRepository , CartRepository>();



            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
