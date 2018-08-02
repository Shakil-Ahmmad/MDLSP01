//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Mass_Data_Education.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class ClassExams
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ClassExams()
        {
            this.Result = new HashSet<Result>();
        }
    
        public int Id { get; set; }
        public int InstituteID { get; set; }
        public int ClassID { get; set; }
        public int ExamNamesID { get; set; }
        public int TotalMarks { get; set; }
        public bool Deleted { get; set; }
    
        public virtual Institute Institute { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Result> Result { get; set; }
        public virtual ExamNames ExamNames { get; set; }
        public virtual Class Class { get; set; }
    }
}
