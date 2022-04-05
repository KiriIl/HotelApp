using HotelBooking.BLL.DTOModels;
using HotelBooking.Common.Enums;
using System.Security.Claims;

namespace HotelBooking.BLL.Services.IServices
{
    public interface IUserService
    {
        ClaimsPrincipal GetPrincipal(string login, string role);
        bool FindExitstLogin(string login);
        void SaveUser(UserDTO user);
        bool CheckUserLogin(string login, string password);
        Role GetUserRole(string login);
        UserDTO GetUserInfo(string login);
    }
}