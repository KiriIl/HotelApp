using HotelBooking.Common.Enums;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelBooking.DAL.Models
{
    public class Apartment : BaseModel
    {
        public ICollection<Booking> Booking { get; set; }
        public ICollection<Notification> Notifications { get; set; }
        public int RoomsCount { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Cost { get; set; }
        public RoomType RoomType { get; set; }
        public string Info { get; set; }
    }
}