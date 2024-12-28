namespace AirPort.Models.Entities
{
    public class Flight
    {

        public int FlightId { get; set; }   

        public int FlightNumber { get; set; }

        public string DepartureCity {  get; set; }
        
        public string ArrivalCity { get; set; }

        public DateTime Schedule {  get; set; }

        public string Status { get; set; }

        public int AirlineID { get; set; }

        public IEnumerable<Booking> Bookings { get; set; }

        public Airline Airline { get; set; }
    }
}
