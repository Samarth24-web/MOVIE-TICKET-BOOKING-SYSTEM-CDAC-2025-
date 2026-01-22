using Microsoft.EntityFrameworkCore;
using MovieTicketBookingSystem.Data;

namespace MovieTicketBookingSystem
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();

            builder.Services.AddDbContext<MovieBookingDbContext>(options =>
            options.UseSqlServer("name=MovieTicketBookingDB"));

            builder.Services.AddScoped<MovieBookingDbContext>();

            var app = builder.Build();

            app.MapDefaultControllerRoute();
            app.MapGet("/", () => "Hello World!");

            app.Run();
        }
    }
}
