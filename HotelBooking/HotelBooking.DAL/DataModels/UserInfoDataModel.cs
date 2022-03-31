using HotelBooking.Common.Enums;

namespace HotelBooking.DAL.DataModels
{
    public class UserInfoDataModel
    {
        public int UserId { get; set; }
        public string Login { get; set; }
        public string Name { get; set; }
        public Role Role { get; set; }
    }
}