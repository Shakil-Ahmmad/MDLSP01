using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Mass_Data_Education.Models
{
    public class PersonMetaData
    {
        [Remote("IsIdExists", "AdminProfile", ErrorMessage = "Id Exists. Please Try Another", AdditionalFields = "Email")]
        [Required(ErrorMessage = "Please Provide a Unique ID")]
        public string Id { get; set; }
        
        public Nullable<int> InstituteID { get; set; }
        
        [Required(ErrorMessage = "Please Provide a Value For This Field")]
        public string Name { get; set; }
        
        public string Type { get; set; }

        [RegularExpression(@"(\+88|^)(?:\s|-)?01[5-9](?:\s|-)?\d(?:\s|-)?\d(?:\s|-)?\d\d\d\d{3}$", ErrorMessage = "Enter a Valid Bangladeshi Number")]
        [Required(ErrorMessage = "Please Provide a Value For This Field")]
        public string Mobile { get; set; }
        
        [EmailAddress]
        [Required(ErrorMessage = "Please Provide a Value For This Field")]
        [Remote("IsEmailExists", "AdminProfile", ErrorMessage = "Email Exists. Please Try Another", AdditionalFields = "Id")]
        public string Email { get; set; }

        [Display(Name = "Father's Name")]
        public string FathersName { get; set; }

        [Display(Name = "Mother's Name")]
        public string MothersName { get; set; }

        [RegularExpression(@"(\+88|^)(?:\s|-)?01[5-9](?:\s|-)?\d(?:\s|-)?\d(?:\s|-)?\d\d\d\d{3}$", ErrorMessage = "Enter a Valid Bangladeshi Number")]
        [Display(Name = "Gurdian Number")]
        public string GurdiansNumber { get; set; }

        [Display(Name = "Designation")]
        public int DesignationID { get; set; }
        
        [Display(Name = "Gender"), Required(ErrorMessage = "Please Select Gender")]
        public int GenderID { get; set; }
        
        [Display(Name = "Blood Group"), Required(ErrorMessage = "Please Select Blood Group")]
        public int BloodGroupID { get; set; }
        
        [Display(Name = "Religion"), Required(ErrorMessage = "Please Select Religion")]
        public int ReligionID { get; set; }
        
        public string Image { get; set; }
        
        public DateTime Date { get; set; }
        
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Please Provide a Value For This Field")]
        public string Password { get; set; }
        
    }
    [MetadataType(typeof(PersonMetaData))]
    public partial class Person { }
}