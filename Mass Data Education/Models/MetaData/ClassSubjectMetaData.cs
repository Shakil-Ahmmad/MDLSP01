using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Mass_Data_Education.Models
{
    public class ClassSubjectMetaData
    {
        [Display(Name = "Class"), Required(ErrorMessage = "Please Provide a Value For This Field")]
        public int ClassId { get; set; }
        [Display(Name = "Subject Names"), Required(ErrorMessage = "Please Provide a Value For This Field")]
        public string SubjectNames { get; set; }
    }
    [MetadataType(typeof(ClassSubjectMetaData))]
    public partial class ClassSubject { }
}