using AutoMapper;
using HotelBooking.Common.Enums;
using HotelBooking.DAL.DataModels;
using HotelBooking.DAL.Models;
using HotelBooking.DAL.Repositories.IRepositories;
using System.Collections.Generic;
using System.Linq;

namespace HotelBooking.DAL.Repositories
{
    public class NotificationRepository : BaseRepository<Notification>, INotificationRepository
    {
        private IMapper _mapper;
        public NotificationRepository(
            HotelBookingDbContext context,
            IMapper mapper) : base(context)
        {
            _mapper = mapper;
        }

        public List<NotificationDataModel> GetByUser(long userId)
        {
            var userNotifications = (from notifications in context.Notifications
                                     where notifications.UserId == userId && notifications.Status != Status.Awaiting
                                     select new NotificationDataModel
                                     {
                                         Id = notifications.Id,
                                         Message = notifications.Message,
                                         Status = notifications.Status,
                                     }).ToList();

            return userNotifications;
        }

        public void ChangeStatus(long notificationId, Status newStatus)
        {
            var currentNotification = (from notification in context.Notifications
                                       where notification.Id == notificationId
                                       select notification).SingleOrDefault();
            currentNotification.Status = newStatus;
            Save(currentNotification);
        }

        public List<NotificationDataModel> GetByUserApartment(long userId, long apartmentId)
        {
            var notificationCollection = (from notifications in context.Notifications
                                          where notifications.UserId == userId && notifications.ApartmentId == apartmentId
                                          select new NotificationDataModel
                                          {
                                              Id = notifications.Id,
                                              Message = notifications.Message,
                                              Status = notifications.Status,
                                          }).ToList();
            return notificationCollection;
        }

        public void CreateNotification(NotificationDataModel notificationModel)
        {
            Save(_mapper.Map<Notification>(notificationModel));
        }

        public List<NotificationDataModel> GetAwaitingNotifications()
        {
            var userNotifications = (from notifications in context.Notifications
                                     where notifications.Status == Status.Awaiting
                                     select new NotificationDataModel
                                     {
                                         Id = notifications.Id,
                                         Message = notifications.Message,
                                         Status = notifications.Status,
                                         NotificationType = notifications.NotificationType,
                                         ApartmentId = notifications.ApartmentId,
                                         UserId = notifications.UserId,
                                     }).ToList();

            return userNotifications;
        }
    }
}