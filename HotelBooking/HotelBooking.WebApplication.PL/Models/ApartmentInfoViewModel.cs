using HotelBooking.Common.Enums;

namespace HotelBooking.WebApplication.PL.Models
{
    public class ApartmentInfoViewModel
    {
        public long Id{ get; set; }
        public int RoomsCount { get; set; }
        public decimal Cost { get; set; }
        public RoomType RoomType { get; set; }
        public string Info { get; set; }
    }
}