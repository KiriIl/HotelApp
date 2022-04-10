using HotelBooking.DAL.DataModels;
using HotelBooking.DAL.Models;
using HotelBooking.DAL.Repositories.IRepositories;
using System.Collections.Generic;
using System.Linq;

namespace HotelBooking.DAL.Repositories
{
    public class NotificationRepository : BaseRepository<Notification>, INotificationRepository
    {
        public NotificationRepository(HotelBookingDbContext context) : base(context) { }

        public List<NotificationDataModel> GetByUser(long userId)
        {
            var userNotifications = (from notifications in context.Notifications
                                     where notifications.UserId == userId
                                     select new NotificationDataModel
                                     {
                                         Id = notifications.Id,
                                         Message = notifications.Message,
                                         Status = notifications.Status,
                                     }).ToList();

            return userNotifications;
        }
    }
}