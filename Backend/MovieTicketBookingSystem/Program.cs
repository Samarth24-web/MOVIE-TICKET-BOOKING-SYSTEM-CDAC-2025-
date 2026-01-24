using Amazon;
using Amazon.S3;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using MovieTicketBookingSystem.AwsUtils;
using MovieTicketBookingSystem.Data;
using MovieTicketBookingSystem.Models;
using MovieTicketBookingSystem.Repository.Implementation;
using MovieTicketBookingSystem.Repository.Interfaces;
using MovieTicketBookingSystem.Services.Implementation;
using MovieTicketBookingSystem.Services.Interfaces;
using System.Text;

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
            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<IAuthService, AuthService>();
            builder.Services.AddScoped<IJwtService, JwtService>();
            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddScoped<ICityService, CityService>();
            builder.Services.AddScoped<ICityRepository, CityRepository>();
            builder.Services.AddScoped<ILanguageRepository, LanguageRepository>();
            builder.Services.AddScoped<ILanguageService, LanguageService>();
            builder.Services.AddScoped<IMovieService, MovieService>();
            builder.Services.AddScoped<IMovieRepository, MovieRepository>();
            builder.Services.AddScoped<IFileStorageService, S3FileStorageService>();
            builder.Services.AddScoped<IGenreRepository, GenreRepository>();
            builder.Services.AddScoped<IGenreService, GenreService>();
            builder.Services.AddScoped<ITheatreManageRequestService, TheatreManagerRequestService>();
            builder.Services.AddScoped<IMovieService, MovieService>();
            builder.Services.AddScoped<ITheatreService, TheatreService>();
            builder.Services.AddScoped<IMovieRepository, MovieRepository>();
            builder.Services.AddScoped<ITheatreRepository, TheatreRepository>();
            builder.Services.AddScoped<ITheatreManagerRequestRepository, TheatreManagerRequestRepository>();
            builder.Services.AddScoped<IScreenService, ScreenService>();
            builder.Services.AddScoped<IScreenRepository, ScreenRepository>();
            builder.Services.AddScoped<ISeatRowService, SeatRowService>();
            builder.Services.AddScoped<ISeatRowRepository, SeatRowRepository>();


            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(opt =>
            {
                opt.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,

                    ValidIssuer = builder.Configuration["Jwt:Issuer"],
                    ValidAudience = builder.Configuration["Jwt:Audience"],

                    IssuerSigningKey = new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"])
                    )
                };
            });

            builder.Services.Configure<AwsSettings>(
                builder.Configuration.GetSection("AWS")
            );

            builder.Services.AddSingleton<IAmazonS3>(sp =>
            {
                var aws = sp.GetRequiredService<IOptions<AwsSettings>>().Value;

                return new AmazonS3Client(
                    aws.AccessKey,
                    aws.SecretKey,
                    RegionEndpoint.GetBySystemName(aws.Region)
                );
            });


            var app = builder.Build();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapDefaultControllerRoute();
            app.MapGet("/", () => "Hello World!");

            app.Run();
        }
    }
}
