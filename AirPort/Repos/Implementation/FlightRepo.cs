using AirPort.Models;
using AirPort.Models.Entities;
using AirPort.Repos.IRepos;
using Microsoft.EntityFrameworkCore;

namespace AirPort.Repos.Implementation
{
    public class FlightRepo : IFlightRepo
    {

        private readonly AppDbContext db;
        public FlightRepo(AppDbContext db)
        {
            this.db = db;
        }
        public async Task AddFlight(Flight flight)
        {
            await db.Flights.AddAsync(flight);
            await db.SaveChangesAsync();
        }

        public async Task EditFlight(Flight flightt , int id)
        {
            var flight = await db.Flights.FirstOrDefaultAsync(x => x.FlightId == id);

            flight.FlightNumber = flightt.FlightNumber;
            flight.DepartureCity = flightt.DepartureCity;
            flight.ArrivalCity = flightt.ArrivalCity;
            flight.Schedule = flightt.Schedule;
            flight.Status = flightt.Status;
            flight.AirlineID = flightt.AirlineID;


            db.Flights.Update(flight);
            await db.SaveChangesAsync();
        }

        public async Task<IEnumerable<Airline>> GetAirLines()
        {
            var g = await db.airlines.ToListAsync();
            return g;
        }

        public async Task<Flight> GetFlightByID(int id)
        {
            var Flgihts = await db.Flights.FirstOrDefaultAsync(x => x.FlightId == id);
            return Flgihts;
        }

        public async Task<IEnumerable<Flight>> GetFlights()
        {
            var Flights = await db.Flights.ToListAsync();
            return Flights;
        }

        public async Task RemoveFlight(int id)
        {
            var b = await GetFlightByID(id);
            db.Flights.Remove(b);
            await db.SaveChangesAsync();
        }
    }
}
