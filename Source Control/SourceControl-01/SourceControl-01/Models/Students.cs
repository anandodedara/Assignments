using DataAnnotationsExtensions;
using SourceControl_01.Custom_Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SourceControl_01.Models
{
    public class Students
    {
        [Key]
        [ScaffoldColumn(false)]
        public int ID { get; set; }

        [Required(ErrorMessage ="Enter First Name.")]
        [MaxLength(50)]
        [Display(Name = "First Name")]
        public String FirstName { get; set; }

        [Required(ErrorMessage = "Enter Last Name.")]
        [MaxLength(50)]
        [Display(Name = "Last Name")]
        public String LastName { get; set; }

        [Display(Name = "Gateway Email")]
        [RegularExpression("([a-z]+.[a-z]+@thegatewaycorp.co.in)",ErrorMessage ="Please enter valid Email.")]
        public String Email { get; set; }

        [Required(ErrorMessage ="Enter Date of Birth.")]
        [Display(Name ="Date of Birth")]
        [DataType(DataType.Date)]
        [AgeValidator]
        public DateTime DOB { get; set; }

        
        [DataType(DataType.Password)]
        [PasswordValidator]
        [MinLength(8),MaxLength(15)]
        public String Password { get; set; }

        
        [NotMapped]
        [DataType(DataType.Password)]
        [Display(Name ="Confirm Password")]
        //Here Compare is not working
        [Compare("Password",ErrorMessage ="Password and Confirm password does not match.")]
        public String RePassword { get; set; }

    }
}