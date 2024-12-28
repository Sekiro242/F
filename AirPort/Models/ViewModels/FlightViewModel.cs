using AirPort.Models.Entities;

namespace AirPort.Models.ViewModels
{
    public class FlightViewModel
    {

        public int      FlightNumber  { get; set; }

        public string   DepartureCity { get; set; }

        public string   ArrivalCity   { get; set; }

        public DateTime Schedule      { get; set; }

        public string   Status        { get; set; }

        public int      AirlineID     { get; set; }

        public IEnumerable<Airline> Airlines { get; set; }
    }
}
