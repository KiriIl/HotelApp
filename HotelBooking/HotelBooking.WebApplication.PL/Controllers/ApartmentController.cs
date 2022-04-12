using AutoMapper;
using HotelBooking.BLL.DTOModels;
using HotelBooking.BLL.Services.IServices;
using HotelBooking.WebApplication.PL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Security.Claims;

namespace HotelBooking.WebApplication.PL.Controllers
{
    [Authorize]
    public class ApartmentController : Controller
    {
        private IMapper _mapper;
        private IApartmentService _apartmentService;
        private IBookingService _bookingService;
        private IUserService _userService;

        public ApartmentController(
            IMapper mapper,
            IApartmentService apartmentService,
            IBookingService bookingService,
            IUserService userService)
        {
            _mapper = mapper;
            _apartmentService = apartmentService;
            _bookingService = bookingService;
            _userService = userService;
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult CreateApartment()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
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
        public IActionResult BookingApartment(long apartmentId)
        {
            var apartmentViewModel = _mapper.Map<ApartmentInfoViewModel>(_apartmentService.Get(apartmentId));
            var viewModel = new BookingApartmentViewModel() { Apartment = apartmentViewModel };
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult BookingApartment(BookingApartmentViewModel viewModel)
        {
            if (viewModel.DepartureDate < viewModel.ArrivalDate)
            {
                ModelState.AddModelError("DepartureDate", "Wrong input");
                return View();
            }
            else if(viewModel.DepartureDate == viewModel.ArrivalDate)
            {
                ModelState.AddModelError("ArrivalDate", "Can not be a same day");
                ModelState.AddModelError("DepartureDate", "Can not be a same day");
                return View();
            }

            if (ModelState.IsValid)
            {
                viewModel.ArrivalDate = viewModel.ArrivalDate.AddHours(9);
                viewModel.DepartureDate = viewModel.DepartureDate.AddHours(6);

                var login = User.Claims.SingleOrDefault(x => x.Type == ClaimsIdentity.DefaultNameClaimType).Value;
                viewModel.User = _mapper.Map<UserInfoViewModel>(_userService.GetUserInfo(login));
                bool success = _bookingService.BookingApartment(_mapper.Map<BookingDTO>(viewModel));

                if (!success)
                {
                    ModelState.AddModelError("ArrivalDate", "Some dates are occupied");
                    return View();
                }
            }

            return RedirectToAction("Index", "Home");
        }
    }
}