using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Mass_Data_Education.Models
{
    public class ReferencePersonMetaData
    {
        [Display(Name = "Name"), Required(ErrorMessage = "Please Provide a Value For This Field")]
        public string Name { get; set; }
        [Display(Name = "Phone"), Required(ErrorMessage = "Please Provide a Value For This Field")]
        public string PhoneNo { get; set; }
        [Display(Name = "Address"), Required(ErrorMessage = "Please Provide a Value For This Field")]
        public string Address { get; set; }
    }
    [MetadataType(typeof(ReferencePersonMetaData))]
    public partial class ReferencePerson { }
}