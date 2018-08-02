using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Mass_Data_Education.Models
{
    public class SectionMetaData
    {
        [Display(Name = "Name"), Required(ErrorMessage = "Please Provide a Value For This Field")]
        public string Name { get; set; }
        [Display(Name = "Class"), Required(ErrorMessage = "Please Provide a Value For This Field")]
        public int ClassID { get; set; }
    }
    [MetadataType(typeof(SectionMetaData))]
    public partial class Section { }
}