using HotelBooking.DAL.DataModels;
using HotelBooking.DAL.Models;
using System.Collections.Generic;

namespace HotelBooking.DAL.Repositories.IRepositories
{
    public interface IApartmentRepository : IBaseRepository<Apartment>
    {
        List<ApartmentDataModel> GetAll();
    }
}