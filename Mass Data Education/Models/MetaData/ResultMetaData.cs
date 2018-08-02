using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Mass_Data_Education.Models
{
    public class ResultMetaData
    {
        [Display(Name = "Person"), Required(ErrorMessage = "Please Provide a Value For This Field")]
        public string PersonID { get; set; }
        [Display(Name = "Class"), Required(ErrorMessage = "Please Provide a Value For This Field")]
        public int ClassID { get; set; }

        [Display(Name = "Institute"), Required(ErrorMessage = "Please Provide a Value For This Field")]
        public int InstituteID { get; set; }
        [Display(Name = "Class Subject"), Required(ErrorMessage = "Please Provide a Value For This Field")]
        public int ClassSubjectID { get; set; }
        [Display(Name = "Class Exams"), Required(ErrorMessage = "Please Provide a Value For This Field")]
        public int ClassExamsID { get; set; }
        [Display(Name = "Total Marks"), Required(ErrorMessage = "Please Provide a Value For This Field")]
        public int TotalMarks { get; set; }
        [Display(Name = "Gotten Marks"), Required(ErrorMessage = "Please Provide a Value For This Field")]
        public int GottenMarks { get; set; }
        [Display(Name = "Grade"), Required(ErrorMessage = "Please Provide a Value For This Field")]
        public string Grade { get; set; }
    }

    [MetadataType(typeof(ResultMetaData))]
    public partial class Result { }
}