using HotelBooking.BLL.DTOModels;

namespace HotelBooking.BLL.Services.IServices
{
    public interface IApartmentService
    {
        void CreateApartment(ApartmentDTO apartment);
    }
}