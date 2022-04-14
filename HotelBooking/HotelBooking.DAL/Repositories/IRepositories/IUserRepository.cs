using HotelBooking.Common.Enums;
using HotelBooking.DAL.DataModels;
using HotelBooking.DAL.Models;

namespace HotelBooking.DAL.Repositories.IRepositories
{
    public interface IUserRepository : IBaseRepository<User>
    {
        UserDataModel Get(string login);
        bool CheckUserLogin(string login, string password);
        Role GetUserRole(string login);
        UserDataModel GetProfileInfo(long userId);
    }
}