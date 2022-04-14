using HotelBooking.Common.Enums;
using HotelBooking.Common.ResourceFiles;
using System.ComponentModel.DataAnnotations;

namespace HotelBooking.WebApplication.PL.Models
{
    public class ApartmentInfoViewModel
    {
        public long Id{ get; set; }
        [Display(ResourceType = typeof(TitleResource), Name = "ApartmentRoomsCount")]
        public int RoomsCount { get; set; }
        public decimal Cost { get; set; }
        [Display(ResourceType = typeof(TitleResource), Name = "ApartmentRoomType")]
        public RoomType RoomType { get; set; }
        public string Info { get; set; }
    }
}