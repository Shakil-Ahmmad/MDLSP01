using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Mass_Data_Education.Models
{
    public class StudentAttendanceMetaData
    {
        [Display(Name = "Class"), Required(ErrorMessage = "Please Provide a Value For This Field")]
        public int ClassID { get; set; }
        [Display(Name = "Person"), Required(ErrorMessage = "Please Provide a Value For This Field")]
        public string PersonID { get; set; }
        [Display(Name = "Date"), Required(ErrorMessage = "Please Provide a Value For This Field")]
        public System.DateTime Date { get; set; }
    }

    [MetadataType(typeof(StudentAttendanceMetaData))]
    public partial class StudentAttendance { }
}