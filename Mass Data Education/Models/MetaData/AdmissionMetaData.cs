using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Mass_Data_Education.Models
{
    public class AdmissionMetaData
    {
        [Display(Name = "Person"), Required(ErrorMessage = "Please Provide a Value For This Field")]
        public string PersonID { get; set; }
        [Display(Name = "Institute"), Required(ErrorMessage = "Please Provide a Value For This Field")]
        public int InstituteID { get; set; }
        [Display(Name = "Reference Person"), Required(ErrorMessage = "Please Provide a Value For This Field")]
        public Nullable<int> ReferencePersonNameId { get; set; }

        [Display(Name = "Admission"), Required(ErrorMessage = "Please Provide a Value For This Field")]
        public System.DateTime AdmissionDate { get; set; }
    }

    [MetadataType(typeof(AdmissionMetaData))]
    public partial class Admission { }
}