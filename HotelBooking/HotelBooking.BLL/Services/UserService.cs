using AutoMapper;
using HotelBooking.BLL.DTOModels;
using HotelBooking.BLL.Services.IServices;
using HotelBooking.Common.Enums;
using HotelBooking.DAL.DataModels;
using HotelBooking.DAL.Models;
using HotelBooking.DAL.Repositories.IRepositories;
using System.Collections.Generic;
using System.Security.Claims;

namespace HotelBooking.BLL.Services
{
    public class UserService : IUserService
    {
        private IMapper _mapper;
        private IUserRepository _userRepository;

        public const string AuthMethod = "ApplicationCookie";

        public UserService(
            IUserRepository userRepository,
            IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public ClaimsPrincipal GetPrincipal(string login, string role)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, login),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, role)
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

        public void SaveUser(UserDTO user)
        {
            var userDM = _mapper.Map<UserDataModel>(user);
            _userRepository.Save(_mapper.Map<User>(userDM));
        }

        public bool CheckUserLogin(string login, string password)
        {
            return _userRepository.CheckUserLogin(login, password);
        }

        public Role GetUserRole(string login)
        {
            return _userRepository.GetUserRole(login);
        }

        public UserDTO GetUserInfo(string login)
        {
            return _mapper.Map<UserDTO>(_userRepository.Get(login));
        }

        public UserDTO GetUserProfile(long userId)
        {
            return _mapper.Map<UserDTO>(_userRepository.GetProfileInfo(userId));
        }
    }
}