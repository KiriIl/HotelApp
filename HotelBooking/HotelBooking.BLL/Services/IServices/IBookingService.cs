using HotelBooking.BLL.DTOModels;

namespace HotelBooking.BLL.Services.IServices
{
    public interface IBookingService
    {
        public bool BookingApartment(BookingDTO booking);
    }
}