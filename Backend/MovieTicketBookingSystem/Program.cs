using Amazon;
using Amazon.S3;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using MovieTicketBookingSystem.AwsUtils;
using MovieTicketBookingSystem.BackgroundJobs;
using MovieTicketBookingSystem.Configuration;
using MovieTicketBookingSystem.Data;
using MovieTicketBookingSystem.Filters;
using MovieTicketBookingSystem.Infrastructure.PaymentGateways;
using MovieTicketBookingSystem.Repository.Implementation;
using MovieTicketBookingSystem.Repository.Interfaces;
using MovieTicketBookingSystem.Services.Implementation;
using MovieTicketBookingSystem.Services.Interfaces;
using MovieTicketBookingSystem.SignalR;
using MovieTicketBookingSystem.Utilities;
using System.Text;

namespace MovieTicketBookingSystem
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Controllers + Filters
            builder.Services.AddControllers(options =>
            {
                options.Filters.Add<TransactionFilter>();
            });
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowFrontend",
                    policy => policy
                        .WithOrigins("http://localhost:5173")
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                        .AllowCredentials());
            });


            // DbContext
            builder.Services.AddDbContext<MovieBookingDbContext>(options =>
                options.UseSqlServer(
                    builder.Configuration.GetConnectionString("MovieTicketBookingDB"))
            );

            // SignalR
            builder.Services.AddSignalR();

            // ================= CONFIGURATION =================

            builder.Services.Configure<RazorpayConfig>(
                builder.Configuration.GetSection("Razorpay"));

            // ?? THIS LINE FIXES YOUR ERROR
            builder.Services.AddSingleton(sp =>
                sp.GetRequiredService<IOptions<RazorpayConfig>>().Value);

            builder.Services.Configure<SeatLockConfig>(
                builder.Configuration.GetSection("SeatLock"));

            builder.Services.Configure<JobConfig>(
                builder.Configuration.GetSection("Jobs"));

            builder.Services.Configure<SignalRConfig>(
                builder.Configuration.GetSection("SignalR"));

            builder.Services.Configure<AwsSettings>(
                builder.Configuration.GetSection("AWS"));

            // ================= REPOSITORIES =================

            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<ICityRepository, CityRepository>();
            builder.Services.AddScoped<ILanguageRepository, LanguageRepository>();
            builder.Services.AddScoped<IMovieRepository, MovieRepository>();
            builder.Services.AddScoped<IGenreRepository, GenreRepository>();
            builder.Services.AddScoped<ITheatreRepository, TheatreRepository>();
            builder.Services.AddScoped<ITheatreManagerRequestRepository, TheatreManagerRequestRepository>();
            builder.Services.AddScoped<IScreenRepository, ScreenRepository>();
            builder.Services.AddScoped<ISeatRowRepository, SeatRowRepository>();
            builder.Services.AddScoped<ISeatRepository, SeatRepository>();
            builder.Services.AddScoped<IShowRepository, ShowRepository>();
            builder.Services.AddScoped<IShowSeatStatusRepository, ShowSeatStatusRepository>();
            builder.Services.AddScoped<IBookingRepository, BookingRepository>();
            builder.Services.AddScoped<IBookingSeatRepository, BookingSeatRepository>();
            builder.Services.AddScoped<ISeatStatusLogRepository, SeatStatusLogRepository>();
            builder.Services.AddScoped<IPaymentRepository, PaymentRepository>();
            builder.Services.AddScoped<IScreenTypeRepository, ScreenTypeRepository>();
            builder.Services.AddScoped<ISeatTypeRepository, SeatTypeRepository>();


            // ================= SERVICES =================

            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddScoped<IAuthService, AuthService>();
            builder.Services.AddScoped<IJwtService, JwtService>();
            builder.Services.AddScoped<ICityService, CityService>();
            builder.Services.AddScoped<ILanguageService, LanguageService>();
            builder.Services.AddScoped<IMovieService, MovieService>();
            builder.Services.AddScoped<IGenreService, GenreService>();
            builder.Services.AddScoped<ITheatreService, TheatreService>();
            builder.Services.AddScoped<ITheatreManageRequestService, TheatreManagerRequestService>();
            builder.Services.AddScoped<IScreenService, ScreenService>();
            builder.Services.AddScoped<ISeatRowService, SeatRowService>();
            builder.Services.AddScoped<IShowService, ShowService>();
            builder.Services.AddScoped<IBookingService, BookingService>();
            builder.Services.AddScoped<IPaymentService, PaymentService>();
            builder.Services.AddScoped<ISeatHistoryService, SeatHistoryService>();
            builder.Services.AddScoped<IFileStorageService, S3FileStorageService>();
            builder.Services.AddScoped<IScreenTypeService, ScreenTypeService>();
            builder.Services.AddScoped<ISeatTypeService, SeatTypeService>();

            // Payment Gateway
            builder.Services.AddScoped<IPaymentGateway, RazorpayGateway>();

            // Utilities
            builder.Services.AddSingleton<DateTimeProvider>();

            // AWS S3
            builder.Services.AddSingleton<IAmazonS3>(sp =>
            {
                var aws = sp.GetRequiredService<IOptions<AwsSettings>>().Value;
                return new AmazonS3Client(
                    aws.AccessKey,
                    aws.SecretKey,
                    RegionEndpoint.GetBySystemName(aws.Region));
            });

            // ================= BACKGROUND JOBS =================

            builder.Services.AddHostedService<SeatLockExpiryJob>();
            builder.Services.AddHostedService<PendingBookingCleanupJob>();
            builder.Services.AddHostedService<RazorpayReconciliationJob>();

            // ================= AUTH =================

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
                            Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
                    };
                });

            var app = builder.Build();


            app.UseCors("AllowFrontend");
            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();
            app.MapHub<SeatLockHub>("/seat-lock-hub");

            app.MapDefaultControllerRoute();
            app.MapGet("/", () => "Hello World!");

            app.Run();
        }
    }
}
