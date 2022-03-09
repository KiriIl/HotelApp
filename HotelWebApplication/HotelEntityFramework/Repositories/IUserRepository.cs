using HotelEntityFramework.Models;

namespace HotelEntityFramework.Repositories
{
    public interface IUserRepository : IBaseRepository<User>
    {
        User Get(string login);
        bool LogIn(string login, string password);
    }
}