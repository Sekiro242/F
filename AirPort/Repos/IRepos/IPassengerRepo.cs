using AirPort.Models.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
namespace AirPort.Repos.IRepos
{
    public interface IPassengerRepo
    {

        public Task<IEnumerable<Passenger>> GetPassengers();

        public Task AddPassenger(Passenger passenger);

        public Task RemovePassenger(int id);

        public Task<Passenger> GetPassByID(int id);

        public Task EditPassenger(Passenger passenger);

    }
}
