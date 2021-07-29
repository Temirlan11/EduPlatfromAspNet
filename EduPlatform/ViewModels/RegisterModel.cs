using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace EduPlatform.ViewModels
{
    public class RegisterModel
    {
        [Required(ErrorMessage = "FirstName not specified")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "MiddleName not specified")]
        public string MiddleName { get; set; }

        [Required(ErrorMessage = "LastName not specified")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Age not specified")]
        public int Age { get; set; }

        [Required(ErrorMessage = "Img not specified")]
        public string Img { get; set; }

        [Required(ErrorMessage = "PhoneNumber not specified")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Email not specified")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password not specified")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Incorrect password input")]
        public string ConfirmPassword { get; set; }
    }
}
