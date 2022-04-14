using AutoMapper;
using HotelBooking.BLL.Services.IServices;
using HotelBooking.WebApplication.PL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace HotelBooking.WebApplication.PL.Controllers
{
    [AllowAnonymous]
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

        public IActionResult Index()
        {
            var aparts = _mapper.Map<List<ApartmentInfoViewModel>>(_apartmentService.GetAllApartments());
            return View(aparts);
        }
    }
}