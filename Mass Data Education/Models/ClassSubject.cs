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
    
    public partial class ClassSubject
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ClassSubject()
        {
            this.Result = new HashSet<Result>();
            this.SubjectBook = new HashSet<SubjectBook>();
            this.TeacherClassSubject = new HashSet<TeacherClassSubject>();
        }
    
        public int Id { get; set; }
        public int InstituteID { get; set; }
        public int ClassId { get; set; }
        public string SubjectNames { get; set; }
        public Nullable<int> GroupID { get; set; }
        public bool Deleted { get; set; }
    
        public virtual Class Class { get; set; }
        public virtual Group Group { get; set; }
        public virtual Institute Institute { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Result> Result { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SubjectBook> SubjectBook { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TeacherClassSubject> TeacherClassSubject { get; set; }
    }
}
