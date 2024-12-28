using AirPort.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace AirPort.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Flight> Flights { get; set; }

        public DbSet<Airline> airlines { get; set; }

        public DbSet<Passenger> passenger { get; set; }

        public DbSet<Booking> bookings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Booking>()
                .HasOne(x => x.Flight)
                .WithMany(x => x.Bookings)
                .HasForeignKey(x => x.FlightID);

            modelBuilder.Entity<Booking>()
                .HasOne(x => x.Passenger)
                .WithMany(x => x.bookings)
                .HasForeignKey(x=> x.PassengerID);

            modelBuilder.Entity<Flight>()
                .HasOne(x => x.Airline)
                .WithMany(x => x.Flights)
                .HasForeignKey(x => x.AirlineID);
        }
    }
}
