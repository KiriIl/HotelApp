using HotelBooking.BLL.DTOModels;

namespace HotelBooking.BLL.Services.IServices
{
    public interface IBookingService
    {
        bool BookingApartment(BookingDTO booking);
    }
}