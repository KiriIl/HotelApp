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
        public string PasswordConfirm { get; set; }
        [Required]
        public string Name { get; set; }
    }
}