using AutoMapper;
using HotelBooking.BLL.DTOModels;
using HotelBooking.BLL.Services.IServices;
using HotelBooking.Common.Enums;
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
        private INotificationRepository _notificationRepository;

        public BookingService(
            IMapper mapper,
            IBookingRepository bookingRepository,
            INotificationRepository notificationRepository)
        {
            _mapper = mapper;
            _bookingRepository = bookingRepository;
            _notificationRepository = notificationRepository;
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

                if (booking.NotifyOnEndDate)
                {
                    var notificationModel = new NotificationDataModel()
                    {
                        ApartmentId = booking.Apartment.Id,
                        UserId = booking.User.Id,
                        Status = Status.Awaiting,
                        NotificationType = NotificationType.ForApartmentEndRent,
                        Message = "Your rent is ending",
                    };

                    _notificationRepository.CreateNotification(notificationModel);
                }

                return true;
            }

            return false;
        }
    }
}