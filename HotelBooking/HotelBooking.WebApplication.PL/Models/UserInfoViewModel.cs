using HotelBooking.Common.Enums;

namespace HotelBooking.WebApplication.PL.Models
{
    public class UserInfoViewModel
    {
        public long Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public Role Role { get; set; }
        public string Name { get; set; }
    }
}