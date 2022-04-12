using HotelBooking.BLL.DTOModels;
using HotelBooking.Common.Enums;
using System.Collections.Generic;

namespace HotelBooking.BLL.Services.IServices
{
    public interface INotificationService
    {
        List<NotificationDTO> GetNotificationsByUserId(long userId);
        void ChangeNotificationStatus(long notificationId, Status status);
        bool CreateNotifyOnEndOccupy(long userId, long apartmentId);
        void UpdateNotifications(long userId);
    }
}