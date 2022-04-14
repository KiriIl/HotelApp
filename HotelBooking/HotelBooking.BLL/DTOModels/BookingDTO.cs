using System;

namespace HotelBooking.BLL.DTOModels
{
    public class BookingDTO
    {
        public long Id { get; set; }
        public UserDTO User { get; set; }
        public ApartmentDTO Apartment { get; set; }
        public DateTime ArrivalDate { get; set; }
        public DateTime DepartureDate { get; set; }
        public bool NotifyOnEndDate { get; set; }

    }
}