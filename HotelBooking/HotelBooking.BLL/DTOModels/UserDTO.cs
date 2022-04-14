using HotelBooking.Common.Enums;

namespace HotelBooking.BLL.DTOModels
{
    public class UserDTO
    {
        public long Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public Role Role { get; set; }
        public string Name { get; set; }
    }
}