using AirPort.Models.Entities;

namespace AirPort.Repos.IRepos
{
    public interface IFlightRepo
    {

        public Task<IEnumerable<Flight>> GetFlights();

        public Task AddFlight(Flight flight);

        public Task RemoveFlight(int id);

        public Task<Flight> GetFlightByID(int id);

        public Task EditFlight(Flight flight , int id);

        public Task<IEnumerable<Airline>> GetAirLines();

    }
}
