using HotelBooking.Common.Enums;
using HotelBooking.WebApplication.PL.Models.ValidationAttributes;
using System.ComponentModel.DataAnnotations;

namespace HotelBooking.WebApplication.PL.Models
{
    public class ApartmentViewModel
    {
        [Required]
        [MinValue(1)]
        public int RoomsCount { get; set; }
        [Required]
        [MinValue(0)]
        public decimal Cost { get; set; }
        [Required]
        public RoomType RoomType { get; set; }
        public string Info { get; set; }
    }
}