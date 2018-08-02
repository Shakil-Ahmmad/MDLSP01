using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Mass_Data_Education.Models
{
    public class ClassMetaData
    {
        [Display(Name = "Name"), Required(ErrorMessage = "Please Provide a Value For This Field")]
        public string Name { get; set; }

        [Display(Name = "Institute Name")]
        public int InstituteID { get; set; }
    }

    [MetadataType(typeof(ClassMetaData))]
    public partial class Class { }
}