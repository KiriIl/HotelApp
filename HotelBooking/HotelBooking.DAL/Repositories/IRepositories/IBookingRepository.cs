using HotelBooking.DAL.DataModels;
using HotelBooking.DAL.Models;

namespace HotelBooking.DAL.Repositories.IRepositories
{
    public interface IBookingRepository : IBaseRepository<Booking>
    {
        public void Save(BookingDataModel bookingDataModel);
    }
}