using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using StudentViewTemplatesApp.Validatos;

namespace StudentViewTemplatesApp.Models
{
    public class Address
    {

        public int Id { get; set; }
        [Required]
        [AddressLengthValidator]
        public string Country { get; set; }
        [Required]
        [AddressLengthValidator]
        public string State { get; set; }
        [Required]
        [AddressLengthValidator]
        public string City { get; set; }
    }
}