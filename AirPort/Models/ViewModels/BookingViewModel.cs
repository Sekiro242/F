using AirPort.Models.Entities;

namespace AirPort.Models.ViewModels
{
    public class BookingViewModel
    {
        public int FlightID { get; set; }

        public int PassengerID { get; set; }

        public DateTime BookingDate { get; set; }

        public IEnumerable<Flight> flights { get; set; }

        public IEnumerable<Passenger> passenger { get; set; }
    }
}
