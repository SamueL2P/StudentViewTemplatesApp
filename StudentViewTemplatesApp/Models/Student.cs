using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Web;
using StudentViewTemplatesApp.Validatos;

namespace StudentViewTemplatesApp.Models
{
    public class Student
    {
        public int Id { get; set; }
        [Required]
        [NameValidator]
        public string Name { get; set; }
        [Required]
        [Range(18, 100, ErrorMessage = "Age must be between 18 and 100.")]
        public int Age { get; set; }

        public Address Address { get; set; }
    }
}