using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiProject.Models
{
    public class PersonVM
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string EmailAddress { get; set; }
        public bool Status { get; set; }
    }
}