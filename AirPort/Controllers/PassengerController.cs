using AirPort.Models.Entities;
using AirPort.Repos.IRepos;
using Microsoft.AspNetCore.Mvc;

namespace AirPort.Controllers
{
    public class PassengerController : Controller
    {
        private readonly IPassengerRepo PR;

        public PassengerController(IPassengerRepo PR)
        {
            this.PR = PR;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> GetPassengers()
        {
            var Passes = await PR.GetPassengers();
            return View(Passes);
        }
        [HttpGet]
        public async Task<IActionResult> AddPassenger()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddPassenger(Passenger passenger)
        {
            await PR.AddPassenger(passenger);
            return RedirectToAction("GetPassengers");
        }
        
     
        
        public async Task<IActionResult> RemovePassenger(int id)
        {
            await PR.RemovePassenger(id);
            return RedirectToAction("GetPassengers");
        }

        [HttpGet]

        public async Task<IActionResult> EditPassenger(int id)
        {
            var pass = await PR.GetPassByID(id);
            return View(pass);

        }

        [HttpPost]

        public async Task<IActionResult> EditPassenger(Passenger passenger)
        {
            await PR.EditPassenger(passenger);
            return RedirectToAction("GetPassengers");
        }
    }

}
