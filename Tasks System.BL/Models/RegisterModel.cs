using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasks_System.BL.Models
{
    public class RegisterModel
    {

        [Required(ErrorMessage = " name is required.")]
        [StringLength(128, ErrorMessage = " name cannot be longer than 128 characters.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [StringLength(17, MinimumLength = 8, ErrorMessage = "Password must be between 8 and 17 characters.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public IFormFile Picture { get; set; }
        public string? ProfilePicture { get; set; }



    }
}
