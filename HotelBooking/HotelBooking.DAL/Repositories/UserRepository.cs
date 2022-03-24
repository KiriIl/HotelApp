using HotelBooking.DAL.Models;
using HotelBooking.DAL.Repositories.IRepositories;
using System.Linq;

namespace HotelBooking.DAL.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(HotelBookingDbContext context) : base(context) {}

        public User Get(string login)
        {
            return dbSet.SingleOrDefault(x => x.Login == login);
        }

        public bool LogIn(string login, string password)
        {
            return dbSet.Any(x => x.Login == login && x.Password == password);
        }
    }
}