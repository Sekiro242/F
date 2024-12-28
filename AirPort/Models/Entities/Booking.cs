namespace AirPort.Models.Entities
{
    public class Booking
    {

        public int BookingID { get; set; }

        public int FlightID { get; set; }

        public int PassengerID { get; set; }

        public DateTime BookingDate { get; set; }

        public Flight Flight { get; set; }

        public Passenger Passenger { get; set; }

    }
}
