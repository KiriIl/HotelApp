using System;
using System.ComponentModel.DataAnnotations;

namespace HotelBooking.WebApplication.PL.Models
{
    public class BookingApartmentViewModel
    {
        public ApartmentInfoViewModel Apartment { get; set; }
        public UserInfoViewModel User { get; set; }
        [Required]
        public DateTime ArrivalDate { get; set; }
        [Required]
        public DateTime DepartureDate { get; set; }
        public bool NotifyOnEndDate { get; set; }
    }
}