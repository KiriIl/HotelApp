using HotelBooking.Common.Enums;

namespace HotelBooking.BLL.DTOModels
{
    public class NotificationDTO
    {
        public long Id { get; set; }
        public string Message { get; set; }
        public Status Status { get; set; }
    }
}