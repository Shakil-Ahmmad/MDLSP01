using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Mass_Data_Education.Models
{
    public class BloodGroupMetaData
    {
     
        [Display(Name = "Blood Group Name"), Required(ErrorMessage = "Please Provide a Value For This Field")]
        public string Name { get; set; }

    }

    [MetadataType(typeof(BloodGroupMetaData))]
    public partial class BloodGroup { }

}