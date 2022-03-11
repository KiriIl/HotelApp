using HotelEntityFramework.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelEntityFramework.Models
{
    public class Apartment : BaseModel
    {
        public virtual List<Order> Orders { get; set; }
        public int RoomsCount { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Cost { get; set; }
        public RoomType RoomType { get; set; }
        public string Info { get; set; }
    }
}