using AirPort.Models.Entities;

namespace AirPort.Repos.IRepos
{
    public interface IBookingRepo
    {
        public Task<IEnumerable<Booking>> GetBooking();

        public Task AddBooking(Booking booking);

        public Task RemoveBooking(int id);

        public Task<Booking> GetBookingByID(int id);

        public Task EditBooking(Booking booking , int id);

      


    }
}
