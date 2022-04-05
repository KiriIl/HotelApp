using AutoMapper;
using HotelBooking.Common.Enums;
using HotelBooking.DAL.DataModels;
using HotelBooking.DAL.Models;
using HotelBooking.DAL.Repositories.IRepositories;
using System.Linq;

namespace HotelBooking.DAL.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        private IMapper _mapper;
        public UserRepository(
            HotelBookingDbContext context,
            IMapper mapper) : base(context) 
        {
            _mapper = mapper;
        }

        public override User Get(long id)
        {
            var user = dbSet.Select(x => new User
            {
                Id = x.Id,
                Login = x.Login,
                Name = x.Name,
                Password = x.Password,
                Role = x.Role,
            }).SingleOrDefault();

            return user;
        }

        public UserDataModel Get(string login)
        {
            return _mapper.Map<UserDataModel>(dbSet.SingleOrDefault(x => x.Login == login));
        }

        public bool CheckUserLogin(string login, string password)
        {
            return dbSet.Any(x => x.Login == login && x.Password == password);
        }

        public Role GetUserRole(string login)
        {
            return Get(login).Role;
        }
    }
}