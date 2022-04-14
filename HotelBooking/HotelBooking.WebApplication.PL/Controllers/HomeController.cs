using AutoMapper;
using HotelBooking.BLL.DTOModels;
using HotelBooking.BLL.Services.IServices;
using HotelBooking.WebApplication.PL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HotelBooking.WebApplication.PL.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private IMapper _mapper;
        private IApartmentService _apartmentService;
        private IBookingService _bookingService;

        public HomeController(
            IMapper mapper,
            IApartmentService apartmentService,
            IBookingService bookingService)
        {
            _mapper = mapper;
            _apartmentService = apartmentService;
            _bookingService = bookingService;
        }

        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult CreateApartment()
        {
            return View();
        }

        [Authorize(Roles ="Admin")]
        [HttpPost]
        public IActionResult CreateApartment(ApartmentViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var apartmentDTO = _mapper.Map<ApartmentDTO>(viewModel);

                _apartmentService.CreateApartment(apartmentDTO);

                return RedirectToAction("Index");
            }
            
            return View();
        }
        
        [HttpGet]
        public IActionResult BookingApartment(long id)
        {
            var viewModel = new BookingApartmentViewModel() { IdApartment = id };
            return View(viewModel);
        }

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