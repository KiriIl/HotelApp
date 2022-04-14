using HotelBooking.Common.Enums;

namespace HotelBooking.WebApplication.PL.Models
{
    public class NotificationViewModel
    {
        public long Id { get; set; }
        public string Message { get; set; }
        public Status Status { get; set; }
    }
}
