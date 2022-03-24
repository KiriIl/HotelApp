using HotelBooking.BLL.DTOModels;
using System.Security.Claims;

namespace HotelBooking.BLL.Services
{
    public interface IUserService
    {
        ClaimsPrincipal GetPrincipal(string login);
        bool FindExitstLogin(string login);
        void SaveUser(UserDTO user);
        bool CheckUserLogin(string login, string password);
    }
}