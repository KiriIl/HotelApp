using HotelBooking.DAL.DataModels;
using HotelBooking.DAL.Models;
using System;
using System.Collections.Generic;

namespace HotelBooking.DAL.Repositories.IRepositories
{
    public interface IBookingRepository : IBaseRepository<Booking>
    {
        void Save(BookingDataModel bookingDataModel);
        List<BookingDataModel> GetReservationsByApartmentId(long apartmentId);
        bool IsOccupiedOnDate(long apartmentId, DateTime date);
        bool IsEndOfRentBooking(long apartmentId, long userId, DateTime currentDate, DateTime nextDate);
        void Remove(long bookingId);
        new BookingDataModel Get(long bookingId);
    }
}