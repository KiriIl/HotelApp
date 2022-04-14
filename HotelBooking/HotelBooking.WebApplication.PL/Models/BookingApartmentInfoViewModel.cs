using HotelBooking.Common.ResourceFiles;
using System;
using System.ComponentModel.DataAnnotations;

namespace HotelBooking.WebApplication.PL.Models
{
    public class BookingApartmentInfoViewModel
    {
        public long Id { get; set; }
        public ApartmentInfoViewModel Apartment { get; set; }
        [Display(ResourceType = typeof(TitleResource), Name = "BookingApartmentArrivalDate")]
        public DateTime ArrivalDate { get; set; }
        [Display(ResourceType = typeof(TitleResource), Name = "BookingApartmentDepartureDate")]
        public DateTime DepartureDate { get; set; }
        public bool Deniable { get; set; } = false;
    }
}
