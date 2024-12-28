using AirPort.Models;
using AirPort.Repos.Implementation;
using AirPort.Repos.IRepos;
using Microsoft.EntityFrameworkCore;

namespace AirPort
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddDbContext<AppDbContext>
                (option => option.UseSqlServer(builder.Configuration.GetConnectionString("Conn")));
            builder.Services.AddScoped<IPassengerRepo, PassengerRepo>();
            builder.Services.AddScoped<IFlightRepo, FlightRepo>();
            builder.Services.AddScoped<IBookingRepo, BookingRepo>();
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

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
