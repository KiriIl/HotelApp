using HotelBooking.BLL.DTOModels;
using System.Security.Claims;

namespace HotelBooking.BLL.Services
{
    public interface IUserService
    {
        ClaimsPrincipal GetPrincipal(string login);
        bool FindExitstLogin(string login);
        void CreateUser(UserDTO user);
        bool CheckUser(string login, string password);
    }
}