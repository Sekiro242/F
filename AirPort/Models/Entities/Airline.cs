namespace AirPort.Models.Entities
{
    public class Airline
    {

        public int AirlineID { get; set; }

        public string AirlineName { get; set; }

        public string ContactInfo { get; set; }

        public IEnumerable<Flight> Flights { get; set; }
    }
}
