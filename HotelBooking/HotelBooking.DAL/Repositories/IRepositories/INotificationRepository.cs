using HotelBooking.DAL.DataModels;
using System.Collections.Generic;

namespace HotelBooking.DAL.Repositories.IRepositories
{
    public interface INotificationRepository
    {
        List<NotificationDataModel> GetByUser(long userId);
    }
}