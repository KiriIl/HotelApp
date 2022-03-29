using HotelBooking.Common.Enums;
using HotelBooking.WebApplication.PL.Models.ValidationAttributes;

namespace HotelBooking.WebApplication.PL.Models
{
    public class ApartmentViewModel
    {
        [MinValue(1)]
        public int RoomsCount { get; set; }
        [MinValue(0)]
        public decimal Cost { get; set; }
        public RoomType RoomType { get; set; }
        public string Info { get; set; }
    }
}