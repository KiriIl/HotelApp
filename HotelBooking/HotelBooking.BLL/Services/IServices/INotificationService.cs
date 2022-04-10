using HotelBooking.BLL.DTOModels;
using System.Collections.Generic;

namespace HotelBooking.BLL.Services.IServices
{
    public interface INotificationService
    {
        List<NotificationDTO> GetNotificationsByUserId(long id);
    }
}