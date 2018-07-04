using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EvoClientSPA.Models
{
    public class PersonVM
    {
        public int Id { get; set; }

        [Display(Name = "First Name")]
        [Required]
        [StringLength(15)]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [Required]
        [StringLength(15)]
        public string LastName { get; set; }

        [StringLength(10)]
        [RegularExpression("([1-9][0-9]*)", ErrorMessage = "Invalid number")]
        public string Phone { get; set; }

        [StringLength(50)]
        [Display(Name = "Email Address")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string EmailAddress { get; set; }

        public bool Status { get; set; }

        public string errormsg { get; set; }
    }
}