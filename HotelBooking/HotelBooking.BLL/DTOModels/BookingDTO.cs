using System;

namespace HotelBooking.BLL.DTOModels
{
    public class BookingDTO
    {
        public long IdUser { get; set; }
        public ApartmentDTO Apartment { get; set; }
        public DateTime ArrivalDate { get; set; }
        public DateTime DepartureDate { get; set; }
    }
}