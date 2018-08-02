using System.ComponentModel.DataAnnotations;

namespace Mass_Data_Education.Models
{
    public class ClassExamsMetaData
    {
        
        [Display(Name = "Class"), Required(ErrorMessage = "Please Provide a Value For This Field")]
        public int ClassID { get; set; }
        [Display(Name = "Exam Names"), Required(ErrorMessage = "Please Provide a Value For This Field")]
        public int ExamNamesID { get; set; }
        [Display(Name = "Total Marks"), Required(ErrorMessage = "Please Provide a Value For This Field")]
        [Range(0, 100)]
        public int TotalMarks { get; set; }

    }
    [MetadataType(typeof(ClassExamsMetaData))]
    public partial class ClassExams { }
}