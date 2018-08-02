using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Mass_Data_Education.Models
{
    public class InstituteMetaData
    {
        [Display(Name = "Person")]
        public string PersonID { get; set; }

        [Required(ErrorMessage = "Please Provide a Institute Name")]
        public string Name { get; set; }

        public string Address { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [RegularExpression(@"(\+88|^)(?:\s|-)?01[5-9](?:\s|-)?\d(?:\s|-)?\d(?:\s|-)?\d\d\d\d{3}$", ErrorMessage = "Enter a Valid Bangladeshi Number")]
        public string Phone { get; set; }

        public string Logo { get; set; }
        
    }

    [MetadataType(typeof(InstituteMetaData))]
    public partial class Institute { }
}