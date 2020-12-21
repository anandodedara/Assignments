using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LoginDemo.CustomValidations
{
    public class AgeValidation : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null) {
                DateTime dateOfBirth = (DateTime)value;
                DateTime today = DateTime.Now;
                int age = today.Year - dateOfBirth.Year;

                if (today.DayOfYear < dateOfBirth.DayOfYear)
                    age--;

                if (age < 18) {
                    return new ValidationResult("Your age is < 18. You can not register.");
                }
                else
                    return ValidationResult.Success;
            }
            else
                return new ValidationResult("Please enter Date of Birth.");
        }
    }
}