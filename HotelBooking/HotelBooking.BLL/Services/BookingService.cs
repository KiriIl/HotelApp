using AutoMapper;
using HotelBooking.BLL.DTOModels;
using HotelBooking.BLL.Services.IServices;
using HotelBooking.Common.Enums;
using HotelBooking.Common.ResourceFiles;
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

        private const int ARRIVAL_HOUR = 9;
        private const int DEPARTURE_HOUR = 6;

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
            booking.ArrivalDate = SetArrivalDate(booking.ArrivalDate);
            booking.DepartureDate = SetDepartureDate(booking.DepartureDate);
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
                        Message = TitleResource.NotificationMessageForEndingOfBooking
                    };

                    _notificationRepository.CreateNotification(notificationModel);
                }

                return true;
            }

            return false;
        }

        public void DenyBooking(long bookingId)
        {
            var model = _mapper.Map<BookingDTO>(_mapper.Map<BookingDataModel>(_bookingRepository.Get(bookingId)));
            var currentDate = DateTime.UtcNow;
            if (currentDate < model.ArrivalDate)
            {
                _bookingRepository.Remove(model.Id);
            }
            else
            {
                model.DepartureDate = SetDepartureDate(currentDate);
            }
        }

        private DateTime SetDepartureDate(DateTime departureDate)
        {
            return new DateTime(departureDate.Year, departureDate.Month, departureDate.Day, DEPARTURE_HOUR, 0, 0);
        }

        private DateTime SetArrivalDate(DateTime arrivalDate)
        {
            return new DateTime(arrivalDate.Year, arrivalDate.Month, arrivalDate.Day, ARRIVAL_HOUR, 0, 0);
        }
    }
}