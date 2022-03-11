using System.Security.Claims;

namespace HotelBLL.Services
{
    public interface IUserService
    {
        ClaimsPrincipal GetPrincipal(string login);
    }
}