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

        public override Booking Get(long id)
        {
            var booking = dbSet.Select(x => new Booking
            {
                Id = x.Id,
                ArrivalDate = x.ArrivalDate,
                DepartureDate = x.DepartureDate,
            }).SingleOrDefault(x => x.Id == id);

            return booking;
        }

        BookingDataModel IBookingRepository.Get(long bookingId)
        {
            var model = Get(bookingId);
            return _mapper.Map<BookingDataModel>(model);
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

        public bool IsOccupiedOnDate(long apartmentId, DateTime date)
        {
            var result = (from booking in context.Booking
                          where booking.ApartmentId == apartmentId &&
                          (booking.ArrivalDate < date && booking.DepartureDate > date)
                          select booking);

            return result.Any();
        }

        public bool IsEndOfRentBooking(long apartmentId, long userId, DateTime currentDate, DateTime nextDate)
        {
            var result = (from booking in context.Booking
                          where (booking.ApartmentId == apartmentId && booking.UserId == userId) &&
                          (currentDate < booking.DepartureDate && nextDate > booking.DepartureDate)
                          select booking);

            return result.Any();
        }
    }
}