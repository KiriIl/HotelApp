using AutoMapper;
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

        public UserDataModel Get(string login)
        {
            return _mapper.Map<UserDataModel>(dbSet.SingleOrDefault(x => x.Login == login));
        }

        public bool CheckUserLogin(string login, string password)
        {
            return dbSet.Any(x => x.Login == login && x.Password == password);
        }
    }
}