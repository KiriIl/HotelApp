using HotelBooking.DAL.DataModels;
using HotelBooking.DAL.Models;

namespace HotelBooking.DAL.Repositories.IRepositories
{
    public interface IUserRepository : IBaseRepository<User>
    {
        UserDataModel Get(string login);
        bool CheckUserLogin(string login, string password);
    }
}