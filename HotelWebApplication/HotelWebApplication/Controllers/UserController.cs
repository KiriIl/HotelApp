using AutoMapper;
using HotelBLL.DTOModels;
using HotelBLL.Services;
using HotelWebApplication.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HotelWebApplication.Controllers
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
                    _userService.CreateUser(_mapper.Map<UserDTO>(viewModel));

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
                var logIn = _userService.CheckUser(viewModel.Login, viewModel.Password);

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