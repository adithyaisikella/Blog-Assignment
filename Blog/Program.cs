using Blog.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Blog
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Configuration.AddJsonFile("appsettings.json");
            builder.Services.AddDbContext<BlogDBContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("BlogDBContext") ?? throw new InvalidOperationException("Connection string 'BlogDBContext' not found.")));
            // Add services to the container.
            builder.Services.AddControllersWithViews();
            var app = builder.Build();
           // var connString = app.Configuration.GetConnectionString("DefaultConnection");

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

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Blogs}/{action=Index}");

            app.Run();
        }
    }
}