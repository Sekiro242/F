using AirPort.Models;
using AirPort.Repos.IRepos;
using Microsoft.AspNetCore.Mvc;
using AirPort.Models.Entities;
using AirPort.Models.ViewModels;
namespace AirPort.Controllers
{
    public class FlightController : Controller
    {

        private readonly IFlightRepo FR;
        private readonly IBookingRepo BR;
        private readonly IPassengerRepo PR;
        public FlightController(IFlightRepo FR , IBookingRepo BR, IPassengerRepo PR)
        {
            this.FR = FR;
            this.BR = BR;
            this.PR = PR;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> GetFlights()
        {
           var F = await FR.GetFlights();
            return View(F);
        }
        [HttpGet]
        public async Task<IActionResult> AddFlight(Flight flight , int id)
        {
           
            var AirLines = await FR.GetAirLines();
            
            FlightViewModel flightViewModel = new FlightViewModel()
            {
                 FlightNumber = flight.FlightNumber,


                 DepartureCity = flight.DepartureCity,


                 ArrivalCity = flight.ArrivalCity,


                 Schedule = flight.Schedule,


                 Status = flight.Status,


                 AirlineID = flight.AirlineID,

                 Airlines = AirLines,
            };


            return View(flightViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> AddFlight(Flight flight)
        {
            await FR.AddFlight(flight);
            return RedirectToAction("GetFlights");
        }
        [HttpGet]
        public async Task<IActionResult> RemoveFlight(int id)
        {

            await FR.RemoveFlight(id);
            return RedirectToAction("GetFlights");
        }
        [HttpGet]
        public async Task<IActionResult> EditFlight(Flight flight)
        {
            var AirLines = await FR.GetAirLines();

            FlightViewModel flightViewModel = new FlightViewModel()
            {
                FlightNumber = flight.FlightNumber,


                DepartureCity = flight.DepartureCity,


                ArrivalCity = flight.ArrivalCity,


                Schedule = flight.Schedule,


                Status = flight.Status,


                AirlineID = flight.AirlineID,

                Airlines = AirLines,
            };


            return View(flightViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> EditFlight(Flight flight , int id)
        {
            await FR.EditFlight(flight ,id);
            return RedirectToAction("GetFlights");
        }


    }
}
