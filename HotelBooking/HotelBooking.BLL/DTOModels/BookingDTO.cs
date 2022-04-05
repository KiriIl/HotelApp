using System;

namespace HotelBooking.BLL.DTOModels
{
    public class BookingDTO
    {
        public UserDTO User { get; set; }
        public ApartmentDTO Apartment { get; set; }
        public DateTime ArrivalDate { get; set; }
        public DateTime DepartureDate { get; set; }
    }
}