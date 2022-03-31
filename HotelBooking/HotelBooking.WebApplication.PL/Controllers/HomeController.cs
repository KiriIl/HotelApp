using AutoMapper;
using HotelBooking.BLL.DTOModels;
using HotelBooking.BLL.Services.IServices;
using HotelBooking.WebApplication.PL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HotelBooking.WebApplication.PL.Controllers
{
    public class HomeController : Controller
    {
        private IMapper _mapper;
        private IApartmentService _apartmentService;

        public HomeController(
            IMapper mapper,
            IApartmentService apartmentService)
        {
            _mapper = mapper;
            _apartmentService = apartmentService;
        }

        [Authorize]
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
    }
}