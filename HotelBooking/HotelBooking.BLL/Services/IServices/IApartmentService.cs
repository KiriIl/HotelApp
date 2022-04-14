using HotelBooking.BLL.DTOModels;
using System.Collections.Generic;

namespace HotelBooking.BLL.Services.IServices
{
    public interface IApartmentService
    {
        void CreateApartment(ApartmentDTO apartment);
        ApartmentDTO Get(long id);
        List<ApartmentDTO> GetAllApartments();
    }
}