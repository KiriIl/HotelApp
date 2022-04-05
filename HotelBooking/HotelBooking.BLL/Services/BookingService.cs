using AutoMapper;
using HotelBooking.BLL.DTOModels;
using HotelBooking.BLL.Services.IServices;
using HotelBooking.DAL.DataModels;
using HotelBooking.DAL.Repositories.IRepositories;
using System;
using System.Linq;

namespace HotelBooking.BLL.Services
{
    public class BookingService : IBookingService
    {
        private IMapper _mapper;
        private IBookingRepository _bookingRepository;

        public BookingService(
            IMapper mapper,
            IBookingRepository bookingRepository)
        {
            _mapper = mapper;
            _bookingRepository = bookingRepository;
        }
        public bool BookingApartment(BookingDTO booking)
        {
            var reservsOnApart = _bookingRepository.GetReservationsByApartmentId(booking.Apartment.Id);
            DateTime arrivalDate = booking.ArrivalDate;
            DateTime departureDate = booking.DepartureDate;

            var reservsInPeriod = (from table in reservsOnApart
                                   where (table.ArrivalDate >= arrivalDate && table.ArrivalDate <= departureDate ||
                                   table.DepartureDate >= arrivalDate && table.DepartureDate <= departureDate) ||
                                   (table.ArrivalDate <= arrivalDate && table.ArrivalDate >= departureDate ||
                                   table.DepartureDate <= arrivalDate && table.DepartureDate >= departureDate) ||
                                   (arrivalDate >= table.ArrivalDate && departureDate <= table.DepartureDate)
                                   select table
                                   );

            if (!reservsInPeriod.Any())
            {
                _bookingRepository.Save(_mapper.Map<BookingDataModel>(booking));
                return false;
            }

            return true;
        }
    }
}