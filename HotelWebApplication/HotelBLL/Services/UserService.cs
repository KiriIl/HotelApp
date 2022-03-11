using System.Collections.Generic;
using System.Security.Claims;

namespace HotelBLL.Services
{
    public class UserService : IUserService
    {
        public static string AuthMethod = "ApplicationCookie";

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
    }
}