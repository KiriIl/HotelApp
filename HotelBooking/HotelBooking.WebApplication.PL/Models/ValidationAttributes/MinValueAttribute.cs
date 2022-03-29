﻿using System.ComponentModel.DataAnnotations;

namespace HotelBooking.WebApplication.PL.Models.ValidationAttributes
{
    public class MinValueAttribute : ValidationAttribute
    {
        private readonly int _minValue;

        public MinValueAttribute(int minValue)
        {
            _minValue = minValue;
        }

        public override bool IsValid(object value)
        {
            return (int)value >= _minValue;
        }
    }
}