using System;
using System.ComponentModel.DataAnnotations;

namespace SourceControl_01.Custom_Validation
{
    public class AgeValidator : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {

                DateTime today = DateTime.Now;
                DateTime dob = (DateTime)value;

                Int32 age = (today.Year - dob.Year - 1) +
                                (((today.Month > dob.Month) ||
                                    ((today.Month == dob.Month) && (today.Day >= dob.Day))) ? 1 : 0);

                if (age >= 18)
                {
                    return ValidationResult.Success;
                }
                else {
                    return new ValidationResult("Your age must > 18");
                }



            }
            else
            {
                return new ValidationResult("Please enter Date of Birth.");
            }
        }
    }
}