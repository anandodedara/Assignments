using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMS.Models
{
    public class User
    {

        public int Id { get; set; }

        [Required(ErrorMessage ="Please enter First Name.")]
        [Display(Name ="First Name")]
        [MaxLength(50,ErrorMessage ="First Name can be contain maximum 50 charecters.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please enter Last Name.")]
        [Display(Name = "Last Name")]
        [MaxLength(50, ErrorMessage = "Last Name can be contain maximum 50 charecters.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Please enter Email.")]
        [Display(Name = "Email")]
        [MaxLength(50, ErrorMessage = "Email can be contain maximum 70 charecters.")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please enter Password.")]
        [Display(Name = "Password")]
        [MaxLength(30, ErrorMessage = "Password must between 6 to 30 charecters.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        
        [Compare("Password")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        public string RePassword { get; set; }
    }
}
