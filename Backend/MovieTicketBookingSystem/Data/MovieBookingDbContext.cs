using Microsoft.EntityFrameworkCore;
using MovieTicketBookingSystem.Models;

namespace MovieTicketBookingSystem.Data
{
    public class MovieBookingDbContext : DbContext
    {
        public MovieBookingDbContext(DbContextOptions<MovieBookingDbContext> options)
            : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Theatre> Theatres { get; set; }
        public DbSet<TheatreManagerRequest> TheatreManagerRequests { get; set; }
        public DbSet<Screen> Screens { get; set; }
        public DbSet<ScreenType> ScreenTypes { get; set; }
        public DbSet<Seat> Seats { get; set; }
        public DbSet<SeatRow> SeatRows { get; set; }
        public DbSet<SeatType> SeatTypes { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<MovieGenreMap> MovieGenreMaps { get; set; }
        public DbSet<MovieLanguageMap> MovieLanguageMaps { get; set; }
        public DbSet<Show> Shows { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<BookingSeat> BookingSeats { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<ShowSeatStatus> ShowSeatStatuses { get; set; }
        public DbSet<SeatStatusLog> SeatStatusLogs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<MovieGenreMap>()
                .HasKey(x => new { x.MovieId, x.GenreId });

            modelBuilder.Entity<MovieLanguageMap>()
                .HasKey(x => new { x.MovieId, x.LanguageId });

            modelBuilder.Entity<Movie>()
                .Property(x => x.Rating)
                .HasPrecision(3, 1);

            modelBuilder.Entity<Payment>()
                .Property(x => x.Amount)
                .HasPrecision(10, 2);

            modelBuilder.Entity<Seat>()
                .Property(x => x.Price)
                .HasPrecision(10, 2);

            modelBuilder.Entity<SeatType>()
                .Property(x => x.BasePrice)
                .HasPrecision(10, 2);

            modelBuilder.Entity<ShowSeatStatus>()
                .Property(x => x.PriceAtBooking)
                .HasPrecision(10, 2);
        }

    }

}
