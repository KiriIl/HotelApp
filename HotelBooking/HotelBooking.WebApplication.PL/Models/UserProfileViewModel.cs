using HotelBooking.Common.Enums;
using System.Collections.Generic;

namespace HotelBooking.WebApplication.PL.Models
{
    public class UserProfileViewModel
    {
        public long Id { get; set; }
        public string Login { get; set; }
        public Role Role { get; set; }
        public string Name { get; set; }
        public List<BookingApartmentInfoViewModel> Booking { get; set; }

    }
}