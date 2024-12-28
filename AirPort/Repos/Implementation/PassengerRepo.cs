using AirPort.Models;
using AirPort.Models.Entities;
using AirPort.Repos.IRepos;
using Microsoft.EntityFrameworkCore;

namespace AirPort.Repos.Implementation
{
    public class PassengerRepo : IPassengerRepo
    {
        private readonly AppDbContext db;

        public PassengerRepo(AppDbContext db)
        {
            this.db = db;
        }
        public async Task AddPassenger(Passenger passenger)
        {
            await db.passenger.AddAsync(passenger);
            await db.SaveChangesAsync();
        }

        public async Task EditPassenger(Passenger passenger)
        {
            db.passenger.Update(passenger);
            await db.SaveChangesAsync();
        }

        public async Task<Passenger> GetPassByID(int id)
        {
            var Pass = await db.passenger.FirstOrDefaultAsync(x => x.PassengerID == id);
            return Pass;
        }

        public async Task<IEnumerable<Passenger>> GetPassengers()
        {
            var Passengers = await db.passenger.ToListAsync();
            return Passengers;
        }

        public async Task RemovePassenger(int id)
        {
            var p = await GetPassByID(id);
            db.passenger.Remove(p);
            await db.SaveChangesAsync();
        }
    }
}
