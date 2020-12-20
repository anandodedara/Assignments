using System;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace SourceControl_01.Custom_Validation
{
    public class PasswordValidator : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
              

                String password = value.ToString();

                if (Regex.IsMatch(password, @"^(?=.*[A-Za-z])(?=.*\d)(?=.*[@$!%*#?&])[A-Za-z\d@$!%*#?&]{8,}$"))
                {
                    return ValidationResult.Success;
                }
                else {
                    return new ValidationResult("Minimum 8 characters, at least one letter, one number and one special character");
                }



            }
            else
            {
                return new ValidationResult("Please enter Password.");
            }
        }
    }
}