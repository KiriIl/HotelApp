using HotelBooking.WebApplication.PL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HotelBooking.WebApplication.PL.Controllers
{
    public class HomeController : Controller
    {
        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }

        [Authorize]
        [HttpGet]
        public IActionResult BookingApartment(long id)
        {
            var viewModel = new BookingApartmentViewModel() { IdApartment = id };
            return View(viewModel);
        }

        [Authorize]
        [HttpPost]
        public IActionResult BookingApartment(BookingApartmentViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                //find current user
            }

            return View();
        }
    }
}