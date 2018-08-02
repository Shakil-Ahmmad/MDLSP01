using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Mass_Data_Education.Models
{
    public class StudentClassMetaData
    {
        [Display(Name = "Person"), Required(ErrorMessage = "Please Provide a Value For This Field")]
        public string PersonId { get; set; }
        [Display(Name = "Roll"), Required(ErrorMessage = "Please Provide a Value For This Field")]
        public int Roll { get; set; }
        [Display(Name = "Class"), Required(ErrorMessage = "Please Provide a Value For This Field")]
        public int ClassFee { get; set; }
        [Display(Name = "Class"), Required(ErrorMessage = "Please Provide a Value For This Field")]
        public int ClassID { get; set; }
        [Display(Name = "Year"), Required(ErrorMessage = "Please Provide a Value For This Field")]
        public System.DateTime Year { get; set; }
    }
    [MetadataType(typeof(StudentClassMetaData))]
    public partial class StudentClass { }
}