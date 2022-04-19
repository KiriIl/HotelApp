using AutoMapper;
using HotelBooking.BLL.DTOModels;
using HotelBooking.BLL.Services.IServices;
using HotelBooking.Common.Enums;
using HotelBooking.Common.ResourceFiles;
using HotelBooking.DAL.DataModels;
using HotelBooking.DAL.Repositories.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HotelBooking.BLL.Services
{
    public class NotificationService : INotificationService
    {
        private IMapper _mapper;
        private INotificationRepository _notificationRepository;
        private IBookingRepository _bookingRepository;

        public NotificationService(
            IMapper mapper,
            INotificationRepository notificationRepository,
            IBookingRepository bookingRepository)
        {
            _mapper = mapper;
            _notificationRepository = notificationRepository;
            _bookingRepository = bookingRepository;
        }

        public void ChangeNotificationStatus(long notificationId, Status status)
        {
            _notificationRepository.ChangeStatus(notificationId, status);
        }

        public bool CreateNotifyOnEndOccupy(long userId, long apartmentId)
        {
            var notficationList = _mapper.Map<List<NotificationDTO>>(_notificationRepository.GetByUserApartment(userId, apartmentId));
            if (notficationList.Any(x => x.Status == Status.Awaiting))
            {
                return false;
            }

            var notificationModel = new NotificationDataModel
            {
                Message = TitleResource.NotificationMessageForApartmentIsFreeNow,
                Status = Status.Awaiting,
                NotificationType = NotificationType.ForApartmentEndOccupy,
                UserId = userId,
                ApartmentId = apartmentId,
            };

            _notificationRepository.SaveNotification(notificationModel);

            return true;
        }

        public List<NotificationDTO> GetNotificationsByUserId(long userId)
        {
            return _mapper.Map<List<NotificationDTO>>(_notificationRepository.GetByUser(userId));
        }

        public void UpdateNotifications()
        {
            var currentDate = DateTime.UtcNow;
            var nextDate = currentDate.AddDays(1);
            var listModels = _mapper.Map<List<NotificationDTO>>(_notificationRepository.GetAwaitingNotifications());
            var group1 = listModels.Where(x => x.NotificationType == NotificationType.ForApartmentEndOccupy).ToList();
            var group2 = listModels.Where(x => x.NotificationType == NotificationType.ForApartmentEndRent).ToList();

            foreach (var x in group1)
            {
                var isOccupied = _bookingRepository.IsOccupiedOnDate(x.ApartmentId, currentDate);
                if (!isOccupied)
                {
                    _notificationRepository.ChangeStatus(x.Id, Status.Unchecked);
                }
            }

            foreach (var x in group2)
            {
                var IsEndOfRentBooking = _bookingRepository.IsEndOfRentBooking(x.ApartmentId, x.UserId, currentDate, nextDate);
                if (IsEndOfRentBooking)
                {
                    _notificationRepository.ChangeStatus(x.Id, Status.Unchecked);
                }
            }
        }
    }
}