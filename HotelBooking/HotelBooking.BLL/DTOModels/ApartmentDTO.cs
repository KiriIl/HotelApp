using HotelBooking.Common.Enums;

namespace HotelBooking.BLL.DTOModels
{
    public class ApartmentDTO
    {
        public int IdApartment { get; set; }
        public int RoomsCount { get; set; }
        public decimal Cost { get; set; }
        public RoomType RoomType { get; set; }
        public string Info { get; set; }
    }
}