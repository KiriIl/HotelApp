using Microsoft.EntityFrameworkCore;

namespace HotelBooking.DAL.Models
{
    public class HotelBookingDbContext : DbContext
    {
        public HotelBookingDbContext(DbContextOptions options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Apartment> Apartments { get; set; }
        public DbSet<Booking> Booking { get; set; }
        public DbSet<Notification> Notifications { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasMany(user => user.Booking)
                .WithOne(booking => booking.User)
                .HasForeignKey(x => x.UserId);

            modelBuilder.Entity<Apartment>()
                .HasMany(apartment => apartment.Booking)
                .WithOne(booking => booking.Apartment)
                .HasForeignKey(x=>x.ApartmentId);

            modelBuilder.Entity<User>()
                .HasMany(user => user.Notifications)
                .WithOne(notification => notification.User)
                .HasForeignKey(x => x.UserId);

            modelBuilder.Entity<Apartment>()
                .HasMany(apartment => apartment.Notifications)
                .WithOne(notification => notification.Apartment)
                .HasForeignKey(x=>x.ApartmentId);

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
            base.OnConfiguring(optionsBuilder);
        }
    }
}