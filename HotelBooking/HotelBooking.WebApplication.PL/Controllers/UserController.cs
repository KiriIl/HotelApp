using AutoMapper;
using HotelBooking.BLL.DTOModels;
using HotelBooking.BLL.Services.IServices;
using HotelBooking.WebApplication.PL.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HotelBooking.WebApplication.PL.Controllers
{
    public class UserController : Controller
    {
        private IMapper _mapper;
        private IUserService _userService;

        public UserController(
            IUserService userService,
            IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Registration(RegistrationViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var isExist = _userService.FindExitstLogin(viewModel.Login);

                if (!isExist)
                {
                    _userService.SaveUser(_mapper.Map<UserDTO>(viewModel));

                    await HttpContext.SignInAsync(_userService.GetPrincipal(viewModel.Login));

                    return RedirectToAction("Index", "Home");
                }
            }

            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var logIn = _userService.CheckUserLogin(viewModel.Login, viewModel.Password);

                if (logIn)
                {
                    await HttpContext.SignInAsync(_userService.GetPrincipal(viewModel.Login));
                    return RedirectToAction("Index", "Home");
                }
            }

            return View();
        }
    }
}