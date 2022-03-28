using HotelBooking.Common.Enums;
using System.Collections.Generic;

namespace HotelBooking.DAL.Models
{
    public class User : BaseModel
    {
        public virtual List<Order> Orders { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public Role Role { get; set; }
        public string Name { get; set; }
    }
}