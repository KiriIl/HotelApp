using HotelBooking.Common.Enums;
using System.Collections.Generic;

namespace HotelBooking.DAL.DataModels
{
    public class ApartmentDataModel
    {
        public long Id { get; set; }
        public List<BookingDataModel> Booking { get; set; }
        public int RoomsCount { get; set; }
        public decimal Cost { get; set; }
        public RoomType RoomType { get; set; }
        public string Info { get; set; }
    }
}