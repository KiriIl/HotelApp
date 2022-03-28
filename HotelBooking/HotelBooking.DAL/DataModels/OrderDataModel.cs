using System;

namespace HotelBooking.DAL.DataModels
{
    public class OrderDataModel
    {
        public long Id { get; set; }
        public UserDataModel User { get; set; }
        public ApartmentDataModel Apartment { get; set; }
        public DateTime ArrivalDate { get; set; }
        public DateTime DepartureDate { get; set; }
    }
}