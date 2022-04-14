using System;

namespace HotelBooking.DAL.Models
{
    public class Booking : BaseModel
    {
        public User User { get; set; }
        public long UserId { get; set; }
        public Apartment Apartment { get; set; }
        public long ApartmentId { get; set; }
        public DateTime ArrivalDate { get; set; }
        public DateTime DepartureDate { get; set; }
    }
}