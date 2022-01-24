using Bootcamp1.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Bootcamp1.CustomValidations.FoodValidations
{
    public class CustomPriceValidation : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var Food = (FoodModel)validationContext.ObjectInstance;

            if (Food.FoodName == null)
            {
                return new ValidationResult("Food Name is required.");
            }

            if (Food.FoodName.Length > 5) { 
                return (Food.Price >= 15)
                    ? ValidationResult.Success
                    : new ValidationResult("Price must be at least 15$ because food name is less than 6 characters long.");
            }


            return ValidationResult.Success;
        }
    }
}
