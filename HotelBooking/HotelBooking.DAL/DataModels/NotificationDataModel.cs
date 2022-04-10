using HotelBooking.Common.Enums;

namespace HotelBooking.DAL.DataModels
{
    public class NotificationDataModel
    {
        public long Id { get; set; }
        public string Message { get; set; }
        public Status Status { get; set; }
    }
}