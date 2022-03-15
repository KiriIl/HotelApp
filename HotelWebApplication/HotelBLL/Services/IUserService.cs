using HotelBLL.DTOModels;
using System.Security.Claims;

namespace HotelBLL.Services
{
    public interface IUserService
    {
        ClaimsPrincipal GetPrincipal(string login);
        bool FindExitstLogin(string login);
        void CreateUser(UserDTO user);
        bool CheckUser(string login, string password);
    }
}