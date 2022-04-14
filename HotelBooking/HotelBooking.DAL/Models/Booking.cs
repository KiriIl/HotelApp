using System;

namespace HotelBooking.DAL.Models
{
    public class Booking : BaseModel
    {
        public virtual User User { get; set; }
        public virtual Apartment Apartment { get; set; }
        public DateTime ArrivalDate { get; set; }
        public DateTime DepartureDate { get; set; }
    }
}