using HotelBooking.Common.Enums;
using HotelBooking.DAL.DataModels;
using HotelBooking.DAL.Models;
using System.Collections.Generic;

namespace HotelBooking.DAL.Repositories.IRepositories
{
    public interface INotificationRepository : IBaseRepository<Notification>
    {
        List<NotificationDataModel> GetByUser(long userId);
        void ChangeStatus(long notificationId, Status newStatus);
        List<NotificationDataModel> GetByUserApartment(long userId, long apartmentId);
        void CreateNotification(NotificationDataModel notificationModel);
        List<NotificationDataModel> GetAwaitingNotifications();
    }
}