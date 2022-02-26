using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC_Data_Layer.Models
{
    public class Person
    {
        [Display(Name ="ID")]
        public int PersonID { get; set; }


        [Display(Name = "First Name")]
        public string FirstName { get; set; }


        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        public int Age { get; set; }


        [Display(Name = "Email")]
        public string EmailID { get; set; }

        public string Gender { get; set; }


        [Display(Name = "Address ID")]
        public int AddressID { get; set; }
    }
}