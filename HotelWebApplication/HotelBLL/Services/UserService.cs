using HotelBLL.DTOModels;
using HotelEntityFramework.Models;
using HotelEntityFramework.Models.Enums;
using HotelEntityFramework.Repositories;
using System.Collections.Generic;
using System.Security.Claims;

namespace HotelBLL.Services
{
    public class UserService : IUserService
    {
        private IUserRepository _userRepository;

        public static string AuthMethod = "ApplicationCookie";

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public ClaimsPrincipal GetPrincipal(string login)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, login)
            };

            ClaimsIdentity claimsIdentity = new ClaimsIdentity(
                claims,
                AuthMethod,
                ClaimsIdentity.DefaultNameClaimType,
                ClaimsIdentity.DefaultRoleClaimType);

            return new(claimsIdentity);
        }

        public bool FindExitstLogin(string login)
        {
            var user = _userRepository.Get(login);
            return user != null;
        }

        public void CreateUser(UserDTO user)
        {
            _userRepository.Save(new User() 
            {
                Login = user.Login,
                Password = user.Password,
                Name = user.Name,
                Role = Role.Client,
            });
        }

        public bool CheckUser(string login, string password)
        {
            return _userRepository.LogIn(login, password);
        }
    }
}