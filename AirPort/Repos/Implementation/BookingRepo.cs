using AirPort.Models;
using AirPort.Models.Entities;
using AirPort.Repos.IRepos;
using Microsoft.EntityFrameworkCore;

namespace AirPort.Repos.Implementation
{
    public class BookingRepo : IBookingRepo
    {
        private readonly AppDbContext db;

        public BookingRepo(AppDbContext db)
        {
            this.db = db;
        }

        public async Task AddBooking(Booking booking)
        {
            await db.bookings.AddAsync(booking);
            await db.SaveChangesAsync();
        }

        public async Task EditBooking(Booking booking , int id)
        {
            var book = await GetBookingByID(id);

            book.BookingDate = booking.BookingDate;
            book.FlightID = booking.FlightID;
            book.PassengerID = booking.PassengerID;

            db.bookings.Update(book);
            await db.SaveChangesAsync();

        }

        public async Task<IEnumerable<Booking>> GetBooking()
        {
            var s = await db.bookings.Include(x => x.Passenger).Include(x => x.Flight).ToListAsync();
            return s;
        }

        public async Task<Booking> GetBookingByID(int id)
        {
            var s = await db.bookings.Include(x => x.Passenger).Include(x => x.Flight).FirstOrDefaultAsync(x => x.BookingID == id);
            return s;
        }

        public async Task RemoveBooking(int id)
        {
            var z = await GetBookingByID(id);
            db.bookings.Remove(z);
            await db.SaveChangesAsync();
        }
    }
}
