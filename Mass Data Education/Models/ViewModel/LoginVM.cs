using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Mass_Data_Education.Models
{
    public class LoginVM
    {
        [Required(ErrorMessage = "Please Provide Your User ID")]
        public string Id { get; set; }


        [Required(ErrorMessage = "Please Provide Your Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}