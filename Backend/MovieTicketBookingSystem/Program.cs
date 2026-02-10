using Amazon;
using Amazon.S3;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using MovieTicketBookingSystem.AwsUtils;
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

var builder = WebApplication.CreateBuilder(args);

// ---------------- CONTROLLERS ----------------
builder.Services.AddControllers(options =>
{
    options.Filters.Add<TransactionFilter>();
});

// ---------------- CORS ----------------
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend", policy =>
    policy.AllowAnyOrigin()
          .AllowAnyHeader()
          .AllowAnyMethod());
});

// ---------------- DATABASE ----------------
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

if (!string.IsNullOrWhiteSpace(connectionString))
{
    builder.Services.AddDbContext<MovieBookingDbContext>(options =>
        options.UseSqlServer(connectionString));
}
else
{
    Console.WriteLine("Database connection string not found. DB disabled.");
}

// ---------------- SIGNALR ----------------
builder.Services.AddSignalR();

// ---------------- CONFIG ----------------
builder.Services.Configure<RazorpayConfig>(builder.Configuration.GetSection("Razorpay"));
builder.Services.Configure<AwsSettings>(builder.Configuration.GetSection("AWS"));

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

// ---------------- REPOSITORIES ----------------
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

// ---------------- SERVICES ----------------
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

builder.Services.AddScoped<IPaymentGateway, RazorpayGateway>();
builder.Services.AddSingleton<DateTimeProvider>();

// ---------------- AWS S3 (SAFE) ----------------
builder.Services.AddSingleton<IAmazonS3>(sp =>
{
    var aws = sp.GetRequiredService<IOptions<AwsSettings>>().Value;

    return new AmazonS3Client(
        aws.AccessKey,
        aws.SecretKey,
        RegionEndpoint.GetBySystemName(aws.Region)
    );
});

// ---------------- JWT (SAFE MODE) ----------------
var jwtKey = builder.Configuration["Jwt:Key"];
var jwtIssuer = builder.Configuration["Jwt:Issuer"];
var jwtAudience = builder.Configuration["Jwt:Audience"];

if (!string.IsNullOrEmpty(jwtKey))
{
    builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
        .AddJwtBearer(opt =>
        {
            opt.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = jwtIssuer,
                ValidAudience = jwtAudience,
                IssuerSigningKey =
                    new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey))
            };
        });
}
else
{
    Console.WriteLine("JWT not configured. Authentication disabled.");
}

var app = builder.Build();

// ---------------- MIDDLEWARE ----------------
app.UseCors("AllowFrontend");
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

// ---------------- ENDPOINTS ----------------
app.MapControllers();
app.MapHub<SeatLockHub>("/seat-lock-hub");
app.MapGet("/", () => "Movie Ticket Booking API is running");

app.Run();
