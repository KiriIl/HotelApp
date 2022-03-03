using HotelEntityFramework.Models;
using HotelEntityFramework.Repositories;
using HotelWebApplication.Models;
using Microsoft.AspNetCore.Mvc;

namespace HotelWebApplication.Controllers
{
    public class UserController : Controller
    {
        private UserRepository userRepository;

        public UserController(UserRepository userRepository)
        {
            this.userRepository = userRepository;
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
        public IActionResult Registration(RegistrationViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var findExistLogin = userRepository.Get(viewModel.Login);

                if (findExistLogin == null)
                {
                    var newUser = new User
                    {
                        Login = viewModel.Login,
                        Password = viewModel.Password,
                        Name = viewModel.Name,
                    };

                    userRepository.Save(newUser);
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
        public IActionResult Login(LoginViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var logIn = userRepository.LogIn(viewModel.Login, viewModel.Password);

                if (logIn)
                {
                    //auth
                    return RedirectToAction("Index", "Home");
                }
            }

            return View();
        }
    }
}