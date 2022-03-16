using AutoMapper;
using HotelBLL.DTOModels;
using HotelEntityFramework.Models;
using HotelEntityFramework.Repositories;
using System.Collections.Generic;
using System.Security.Claims;

namespace HotelBLL.Services
{
    public class UserService : IUserService
    {
        private IMapper _mapper;
        private IUserRepository _userRepository;

        public static string AuthMethod = "ApplicationCookie";

        public UserService(
            IUserRepository userRepository,
            IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
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
            _userRepository.Save(_mapper.Map<User>(user));
        }

        public bool CheckUser(string login, string password)
        {
            return _userRepository.LogIn(login, password);
        }
    }
}