using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CoreWithADO.Models
{
    public class UserSignUp
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "User Name")]
        public string name { get; set; }
        [Required]
        [EmailAddress]
        [Display(Name = "Email Address")]
        public string email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Passwrod")]
        public string password { get; set; }
        
        [Required]
        [DataType(DataType.Password)]
        [Compare("password",ErrorMessage ="Confirm password not matched !")]
        [Display(Name = "Confirm Passwrod")]
        public string confirmpassword { get; set; }

        [Display(Name = "Mobile Number")]
        public string mobile { get; set; }

        [Display(Name = "Gender")]

        public string gender { get; set; }
        public string profile { get; set; }

    }

    public class UserSignIn
    {
        [Required]
        [EmailAddress]
        [Display(Name ="Email Address")]
        public string email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Passwrod")]
        public string password { get; set; }

        [Display(Name ="Remember me ?")]
        public bool isremember { get; set; }

    }

}
