using HotelBooking.BLL.DTOModels;

namespace HotelBooking.BLL.Services.IServices
{
    public interface IBookingService
    {
        void BookingApartment(BookingDTO booking);
    }
}