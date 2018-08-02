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
    
    public partial class Result
    {
        public int Id { get; set; }
        public string PersonID { get; set; }
        public int ClassID { get; set; }
        public int InstituteID { get; set; }
        public int ClassSubjectID { get; set; }
        public int ClassExamsID { get; set; }
        public int TotalMarks { get; set; }
        public int GottenMarks { get; set; }
        public string Grade { get; set; }
        public bool Deleted { get; set; }
    
        public virtual Class Class { get; set; }
        public virtual ClassExams ClassExams { get; set; }
        public virtual ClassSubject ClassSubject { get; set; }
        public virtual Institute Institute { get; set; }
        public virtual Person Person { get; set; }
    }
}