using HotelBooking.DAL.DataModels;
using HotelBooking.DAL.Models;

namespace HotelBooking.DAL.Repositories.IRepositories
{
    public interface IBookingRepository : IBaseRepository<Booking>
    {
        void Save(BookingDataModel bookingDataModel);
    }
}