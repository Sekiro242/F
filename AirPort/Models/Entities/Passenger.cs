namespace AirPort.Models.Entities
{
    public class Passenger
    {

       public int  PassengerID { get; set; }

        public string PassengerName { get; set; }

        public string ContactInfo { get; set; }

        public string NationalID { get; set; }

        public IEnumerable<Booking> bookings { get; set; }

    }
}
