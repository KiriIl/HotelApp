using HotelBooking.DAL.DataModels;
using HotelBooking.DAL.Models;
using System;
using System.Collections.Generic;

namespace HotelBooking.DAL.Repositories.IRepositories
{
    public interface IBookingRepository : IBaseRepository<Booking>
    {
        void Save(BookingDataModel bookingDataModel);
        bool IsEmpty(long apartmentId, DateTime arrivalDate, DateTime departureDate);
        List<BookingDataModel> GetReservationsByApartmentId(long apartmentId);
    }
}