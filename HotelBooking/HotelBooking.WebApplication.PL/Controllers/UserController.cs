using AutoMapper;
using HotelBooking.BLL.DTOModels;
using HotelBooking.BLL.Services.IServices;
using HotelBooking.WebApplication.PL.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace HotelBooking.WebApplication.PL.Controllers
{
    public class UserController : Controller
    {
        private IMapper _mapper;
        private IUserService _userService;
        private INotificationService _notificationService;

        public UserController(
            IMapper mapper,
            IUserService userService,
            INotificationService notificationService)
        {
            _mapper = mapper;
            _userService = userService;
            _notificationService = notificationService;
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

                    await HttpContext.SignInAsync(_userService.GetPrincipal(viewModel.Login, nameof(viewModel.Role)));

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
                    var role = _userService.GetUserRole(viewModel.Login);
                    await HttpContext.SignInAsync(_userService.GetPrincipal(viewModel.Login, role.ToString()));
                    return RedirectToAction("Index", "Home");
                }
            }

            return View();
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }

        [Authorize]
        [HttpGet]
        public IActionResult GetNotifications()
        {
            var login = User.Claims.SingleOrDefault(x => x.Type == ClaimsIdentity.DefaultNameClaimType).Value;
            var userId = _mapper.Map<UserInfoViewModel>(_userService.GetUserInfo(login)).Id;
            var list = _mapper.Map<List<NotificationViewModel>>(_notificationService.GetNotificationsByUserId(userId));
            return Json(list);
        }
    }
}