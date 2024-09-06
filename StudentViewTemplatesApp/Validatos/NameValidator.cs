using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace StudentViewTemplatesApp.Validatos
{
    public class NameValidator : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                string name = value.ToString();
                if (Regex.IsMatch(name, @"^[a-zA-Z\s]+$"))
                {
                    return ValidationResult.Success;
                }


            }
            return new ValidationResult("Name should contain only alphabets and spaces.");
        }
    }
}