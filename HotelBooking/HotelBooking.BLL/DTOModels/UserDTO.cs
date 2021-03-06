using HotelBooking.Common.Enums;
using System.Collections.Generic;

namespace HotelBooking.BLL.DTOModels
{
    public class UserDTO
    {
        public long Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public List<BookingDTO> Booking { get; set; }
        public Role Role { get; set; }
        public string Name { get; set; }
    }
}