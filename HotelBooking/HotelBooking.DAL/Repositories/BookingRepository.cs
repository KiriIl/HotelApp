using AutoMapper;
using HotelBooking.DAL.DataModels;
using HotelBooking.DAL.Models;
using HotelBooking.DAL.Repositories.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HotelBooking.DAL.Repositories
{
    public class BookingRepository : BaseRepository<Booking>, IBookingRepository
    {
        private IMapper _mapper;

        public BookingRepository(
            HotelBookingDbContext context,
            IMapper mapper) : base(context)
        {
            _mapper = mapper;
        }

        public void Save(BookingDataModel bookingDataModel)
        {
            var bookingModel = new Booking()
            {
                ApartmentId = bookingDataModel.Apartment.Id,
                UserId = bookingDataModel.User.Id,
                ArrivalDate = bookingDataModel.ArrivalDate,
                DepartureDate = bookingDataModel.DepartureDate,
            };

            Save(bookingModel);
        }

        public List<BookingDataModel> GetReservationsByApartmentId(long apartmentId)
        {
            var reservsOnApart = (from apartments in context.Apartments
                                  join booking in context.Booking on apartments.Id equals booking.ApartmentId
                                  where booking.ApartmentId == apartmentId
                                  select new BookingDataModel
                                  {
                                      Id = booking.Id,
                                      ArrivalDate = booking.ArrivalDate,
                                      DepartureDate = booking.DepartureDate,
                                  }).ToList();

            return reservsOnApart;
        }

        public bool IsEmpty(long apartmentId, DateTime arrivalDate, DateTime departureDate)
        {
            var reservsOnApart = GetReservationsByApartmentId(apartmentId);

            var reservsInPeriod = (from table in reservsOnApart
                                   where (table.ArrivalDate >= arrivalDate && table.ArrivalDate <= departureDate ||
                                   table.DepartureDate >= arrivalDate && table.DepartureDate <= departureDate) ||
                                   (table.ArrivalDate <= arrivalDate && table.ArrivalDate >= departureDate ||
                                   table.DepartureDate <= arrivalDate && table.DepartureDate >= departureDate)
                                   select table
                );

            var temp = reservsInPeriod.ToList();

            return !temp.Any();
        }
    }
}