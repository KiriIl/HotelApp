using HotelBooking.Common.Enums;
using HotelBooking.Common.ResourceFiles;
using System.ComponentModel.DataAnnotations;

namespace HotelBooking.WebApplication.PL.Models
{
    public class RegistrationViewModel
    {
        [Required]
        public string Login { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        [Compare("Password", ErrorMessage = "Not matching")]
        [Display(ResourceType = typeof(TitleResource), Name = "RegistrationConfirmPassword")]
        public string PasswordConfirm { get; set; }
        [Required]
        public string Name { get; set; }
        public Role Role { get; set; }
    }
}