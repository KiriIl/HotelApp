using HotelBLL.Services;
using HotelEntityFramework.Models;
using HotelEntityFramework.Repositories;
using HotelWebApplication.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HotelWebApplication.Controllers
{
    public class UserController : Controller
    {
        private IUserRepository _userRepository;
        private IUserService _userService;

        public UserController(
            IUserRepository userRepository,
            IUserService userService)
        {
            _userRepository = userRepository;
            _userService = userService;
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
                var findExistLogin = _userRepository.Get(viewModel.Login);

                if (findExistLogin == null)
                {
                    var newUser = new User
                    {
                        Login = viewModel.Login,
                        Password = viewModel.Password,
                        Name = viewModel.Name,
                    };

                    _userRepository.Save(newUser);

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
                var logIn = _userRepository.LogIn(viewModel.Login, viewModel.Password);

                if (logIn)
                {
                    await HttpContext.SignInAsync(_userService.GetPrincipal(viewModel.Login));
                    return RedirectToAction("Index", "Home");
                }
            }

            return View();
        }

        //public async Task Authentication(string login)
        //{
        //    var claims = new List<Claim>
        //    {
        //        new Claim(ClaimsIdentity.DefaultNameClaimType, login)
        //    };

        //    ClaimsIdentity id = new ClaimsIdentity(
        //        claims,
        //        "ApplicationCookie",
        //        ClaimsIdentity.DefaultNameClaimType,
        //        ClaimsIdentity.DefaultRoleClaimType);

        //    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        //}
    }
}