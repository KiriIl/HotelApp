using HotelBooking.Common.ResourceFiles;
using System;
using System.ComponentModel.DataAnnotations;

namespace HotelBooking.WebApplication.PL.Models
{
    public class BookingApartmentViewModel
    {
        public ApartmentInfoViewModel Apartment { get; set; }
        public UserInfoViewModel User { get; set; }
        public long IdApartment { get; set; }
        public long IdUser { get; set; }
        [Required]
        [Display(ResourceType = typeof(TitleResource), Name = "BookingApartmentArrivalDate")]
        public DateTime ArrivalDate { get; set; }
        [Required]
        [Display(ResourceType = typeof(TitleResource), Name = "BookingApartmentDepartureDate")]
        public DateTime DepartureDate { get; set; }
        [Display(ResourceType = typeof(TitleResource), Name = "QuestionNotifyUser")]
        public bool NotifyOnEndDate { get; set; }
    }
}