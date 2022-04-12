using HotelBooking.DAL.DataModels;
using HotelBooking.DAL.Models;
using System;
using System.Collections.Generic;

namespace HotelBooking.DAL.Repositories.IRepositories
{
    public interface IBookingRepository : IBaseRepository<Booking>
    {
        void Save(BookingDataModel bookingDataModel);
        public List<BookingDataModel> GetReservationsByApartmentId(long apartmentId);
        bool IsOccupiedOnDate(long apartmentId, DateTime date);
    }
}