using System;
using System.ComponentModel.DataAnnotations;

namespace HotelBooking.WebApplication.PL.Models.ValidationAttributes
{
    public class DateAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            var date = Convert.ToDateTime(value);
            var validDate = new DateTime(date.Year, date.Month, date.Day);
            return validDate > DateTime.UtcNow;
        }
    }
}