using HotelEntityFramework.Models.Enums;

namespace HotelBLL.DTOModels
{
    public class UserDTO
    {
        public long IdUser { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public Role Role { get; set; }
        public string Name { get; set; }
    }
}