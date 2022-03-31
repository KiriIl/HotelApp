using AutoMapper;
using HotelBooking.BLL.DTOModels;
using HotelBooking.BLL.Services.IServices;
using HotelBooking.WebApplication.PL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace HotelBooking.WebApplication.PL.Controllers
{
    public class HomeController : Controller
    {
        private IMapper _mapper;
        private IBookingService _bookingService;

        public HomeController(
            IMapper mapper,
            IBookingService bookingService)
        {
            _mapper = mapper;
            _bookingService = bookingService;
        }

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
                _bookingService.BookingApartment(_mapper.Map<BookingDTO>(viewModel));
            }

            return View();
        }
    }
}