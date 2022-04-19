using HotelBooking.BLL.DTOModels;
using System.Collections.Generic;

namespace HotelBooking.BLL.Services.IServices
{
    public interface IApartmentService
    {
        void SaveApartment(ApartmentDTO apartment);
        ApartmentDTO Get(long apartmentId);
        List<ApartmentDTO> GetAllApartments();
    }
}