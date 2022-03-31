using HotelBooking.BLL.DTOModels;

namespace HotelBooking.BLL.Services.IServices
{
    public interface IBookingService
    {
        public void BookingApartment(BookingDTO booking);
    }
}