using HotelBooking.Common.Enums;
using System.Collections.Generic;

namespace HotelBooking.DAL.DataModels
{
    public class UserDataModel
    {
        public long Id { get; set; }
        public List<BookingDataModel> Booking { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public Role Role { get; set; }
        public string Name { get; set; }
    }
}