using HotelBooking.Common.Enums;
using System.Collections.Generic;

namespace HotelBooking.DAL.Models
{
    public class User : BaseModel
    {
        public ICollection<Booking> Booking { get; set; }
        public ICollection<Notification> Notifications { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public Role Role { get; set; }
        public string Name { get; set; }
    }
}