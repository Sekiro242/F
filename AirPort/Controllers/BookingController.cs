using AirPort.Repos.IRepos;
using Microsoft.AspNetCore.Mvc;
using AirPort.Models.Entities;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.View;
using AirPort.Models.ViewModels;


namespace AirPort.Controllers
{
    public class BookingController : Controller
    {
        private readonly IBookingRepo BR;
        private readonly IFlightRepo FR;
        private readonly IPassengerRepo PR;

        public BookingController(IBookingRepo BR, IFlightRepo FR, IPassengerRepo PR)
        {
            this.BR = BR;
            this.FR = FR;
            this.PR = PR;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> GetBooking()
        {
            var l = await BR.GetBooking();
            return View(l);
        }
        [HttpGet]
        public async Task<IActionResult> AddBooknig(Booking booking, int id)
        {
            var Passes = await PR.GetPassengers();
            var Flights = await FR.GetFlights();

            BookingViewModel bookingViewModel = new BookingViewModel()
            {
                BookingDate = booking.BookingDate,
                FlightID = booking.FlightID,
                PassengerID = booking.PassengerID,
                flights = Flights,
                passenger = Passes


            };

            return View(bookingViewModel);

        }
        [HttpPost]
        public async Task<IActionResult> AddBooknig(Booking booking)
        {
            await BR.AddBooking(booking);
            return RedirectToAction("GetBooking");
        }

        public async Task<IActionResult> RemoveBooking(int id)
        {
            await BR.RemoveBooking(id);
            return RedirectToAction("GetBooking");
        }
        [HttpGet]
        public async Task<IActionResult> EditBooking(Booking booking)
        {
            var Passes = await PR.GetPassengers();
            var Flights = await FR.GetFlights();

            BookingViewModel bookingViewModel = new BookingViewModel()
            {
                BookingDate = booking.BookingDate,
                FlightID = booking.FlightID,
                PassengerID = booking.PassengerID,
                flights = Flights,
                passenger = Passes


            };

            return View(bookingViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> EditBooking(Booking booking , int id)
        {
            await BR.EditBooking(booking , id);
            return RedirectToAction("GetBooking");
        }

    }
}
