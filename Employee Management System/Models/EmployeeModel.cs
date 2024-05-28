using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Employee_Management_System.Models
{
    public class EmployeeModel
    {
        public int id { get; set; }
        [DisplayName("Name")]
        [Required]
        public string name { get; set; }
        [DisplayName("Gender")]
        [Required]
        public string gender { get; set; }
        [DisplayName("Email")]
        [EmailAddress]
        [Required]
        public string email { get; set; }
        [DisplayName("Address")]
        [Required]
        public string address { get; set; }
        [DisplayName("Zip Code")]
        [Required]
        public string zipcode { get; set; }
        [DisplayName("State")]
        [Required]
        public string state { get; set; }
        [DisplayName("Phone #")]
        [Required]
        public string phonenumber { get; set; }
        [DisplayName("User ID")]
        public int userID { get; set; }
    }
}