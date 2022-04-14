using HotelBooking.Common.Enums;
using HotelBooking.Common.ResourceFiles;
using HotelBooking.WebApplication.PL.Models.ValidationAttributes;
using System.ComponentModel.DataAnnotations;

namespace HotelBooking.WebApplication.PL.Models
{
    public class ApartmentViewModel
    {
        public long Id { get; set; }
        [Required]
        [MinValue(1)]
        [Display(ResourceType = typeof(TitleResource), Name = "ApartmentRoomsCount")]
        public int RoomsCount { get; set; }
        [Required]
        [MinValue(0)]
        public decimal Cost { get; set; }
        [Required]
        [Display(ResourceType = typeof(TitleResource), Name = "ApartmentRoomType")]
        public RoomType RoomType { get; set; }
        public string Info { get; set; }
    }
}