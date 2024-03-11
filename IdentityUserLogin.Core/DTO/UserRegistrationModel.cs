using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityUserLogin.Core.DTO
{
    public class UserRegistrationModel
    {
        [DisplayName("First Name")]
        [Required]
        public string FirstName { get; set; }
        [DisplayName("Last Name")]
        [Required]
        public string LastName { get; set; }
        [DisplayName("Username")]
        [Required]
        public string UserName { get; set; }
        [DisplayName("Email")]
        [Required]
        [EmailAddress(ErrorMessage = "Email should be in a proper email address format")]
        public string Email { get; set; }
        [DisplayName("Password")]
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [DisplayName("Confirm Password")]
        [Required]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
        [DisplayName("Phone number")]
        [Required]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression("^[0-9]*$")]
        public string PhoneNumber { get; set; }
        public string UserRole { get; set; } = "Anonymous";
    }
}
