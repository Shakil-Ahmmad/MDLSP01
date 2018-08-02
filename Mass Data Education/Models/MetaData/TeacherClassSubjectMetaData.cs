using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Mass_Data_Education.Models
{
    public class TeacherClassSubjectMetaData
    {
        [Display(Name = "Institute"), Required(ErrorMessage = "Please Provide a Value For This Field")]
        public int InstituteID { get; set; }
        [Display(Name = "Person"), Required(ErrorMessage = "Please Provide a Value For This Field")]
        public string PersonID { get; set; }
        [Display(Name = "Class Subject"), Required(ErrorMessage = "Please Provide a Value For This Field")]
        public int ClassSubjectID { get; set; }
    }
    [MetadataType(typeof(TeacherClassSubjectMetaData))]
    public partial class TeacherClassSubject { }
}