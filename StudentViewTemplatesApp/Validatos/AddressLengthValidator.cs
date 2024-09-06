using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StudentViewTemplatesApp.Validatos
{
    public class AddressLengthValidator : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                string desc = value.ToString();
                if (desc.Length < 20)
                {
                    return ValidationResult.Success;
                }

            }
            return new ValidationResult("Max letters 20");
        }
    }
}