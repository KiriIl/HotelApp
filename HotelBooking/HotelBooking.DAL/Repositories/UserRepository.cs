using AutoMapper;
using HotelBooking.Common.Enums;
using HotelBooking.DAL.DataModels;
using HotelBooking.DAL.Models;
using HotelBooking.DAL.Repositories.IRepositories;
using System.Collections.Generic;
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
            }).SingleOrDefault(x => x.Id == id);

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

        public UserDataModel GetProfileInfo(long userId)
        {
            var userModel = (from user in context.Users
                             where user.Id == userId
                             select new UserDataModel
                             {
                                 Id = userId,
                                 Booking = _mapper.Map<List<BookingDataModel>>(user.Booking.ToList()),
                                 Login = user.Login,
                                 Name = user.Name,
                                 Role = user.Role,
                             }).SingleOrDefault();

            userModel.Booking = (from booking in context.Booking
                                 join apartment in context.Apartments on booking.ApartmentId equals apartment.Id
                                 where booking.UserId == userId
                                 select new BookingDataModel
                                 {
                                     Id = userId,
                                     Apartment = _mapper.Map<ApartmentDataModel>(booking.Apartment),
                                     ArrivalDate = booking.ArrivalDate,
                                     DepartureDate = booking.DepartureDate,
                                 }).ToList();

            return userModel;
        }
    }
}