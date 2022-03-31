using System;

namespace HotelBooking.DAL.DataModels
{
    public class BookingDataModel
    {
        public long Id { get; set; }
        public UserDataModel User { get; set; }
        public ApartmentDataModel Apartment { get; set; }
        public DateTime ArrivalDate { get; set; }
        public DateTime DepartureDate { get; set; }
    }
}