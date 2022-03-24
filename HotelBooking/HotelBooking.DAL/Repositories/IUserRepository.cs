using HotelBooking.DAL.Models;

namespace HotelBooking.DAL.Repositories
{
    public interface IUserRepository : IBaseRepository<User>
    {
        User Get(string login);
        bool LogIn(string login, string password);
    }
}