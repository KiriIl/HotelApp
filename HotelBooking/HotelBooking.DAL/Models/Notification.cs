using HotelBooking.Common.Enums;

namespace HotelBooking.DAL.Models
{
    public class Notification : BaseModel
    {
        public string Message { get; set; }
        public Status Status { get; set; }
        public NotificationType NotificationType { get; set; }
        public User User { get; set; }
        public long UserId { get; set; }
        public Apartment Apartment { get; set; }
        public long ApartmentId { get; set; }
    }
}