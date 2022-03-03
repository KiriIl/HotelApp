using HotelEntityFramework.Models;
using System.Linq;

namespace HotelEntityFramework.Repositories
{
    public class UserRepository : BaseRepository<User>
    {
        public UserRepository(MyContext context) : base(context) { }

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