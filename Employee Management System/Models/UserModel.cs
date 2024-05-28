using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Employee_Management_System.Models
{
    public class UserModel
    {
        public int id { get; set; }
        [DisplayName("User Name")]
        [Required]
        [MinLength(3)]
        public string username { get; set; }
        [DisplayName("Gender")]
        [Required]
        public string gender { get; set; }
        [DisplayName("Email")]
        [Required]
        [EmailAddress]
        public string email { get; set; }
        [DisplayName("Password")]
        [Required]
        [MinLength(8)]
        public string password { get; set; }
    }
}