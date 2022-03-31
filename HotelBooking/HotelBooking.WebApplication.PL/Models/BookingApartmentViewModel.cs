using System;
using System.ComponentModel.DataAnnotations;

namespace HotelBooking.WebApplication.PL.Models
{
    public class BookingApartmentViewModel
    {
        //public ApartmentViewModel {get; set;}
        public long IdApartment { get; set; }
        public long IdUser { get; set; }
        [Required]
        public DateTime ArrivalDate { get; set; }
        [Required]
        public DateTime DepartureDate { get; set; }
    }
}