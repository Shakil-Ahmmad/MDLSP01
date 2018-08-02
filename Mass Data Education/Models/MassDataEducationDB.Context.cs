﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class MassDataEducationEntities : DbContext
    {
        public MassDataEducationEntities()
            : base("name=MassDataEducationEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Accounting> Accounting { get; set; }
        public virtual DbSet<Address> Address { get; set; }
        public virtual DbSet<Admission> Admission { get; set; }
        public virtual DbSet<BloodGroup> BloodGroup { get; set; }
        public virtual DbSet<Class> Class { get; set; }
        public virtual DbSet<ClassExams> ClassExams { get; set; }
        public virtual DbSet<ClassSubject> ClassSubject { get; set; }
        public virtual DbSet<Designation> Designation { get; set; }
        public virtual DbSet<ExamNames> ExamNames { get; set; }
        public virtual DbSet<Gender> Gender { get; set; }
        public virtual DbSet<Institute> Institute { get; set; }
        public virtual DbSet<LogData> LogData { get; set; }
        public virtual DbSet<PaymantNames> PaymantNames { get; set; }
        public virtual DbSet<Person> Person { get; set; }
        public virtual DbSet<ReferencePerson> ReferencePerson { get; set; }
        public virtual DbSet<Religion> Religion { get; set; }
        public virtual DbSet<Result> Result { get; set; }
        public virtual DbSet<Section> Section { get; set; }
        public virtual DbSet<StudentAttendance> StudentAttendance { get; set; }
        public virtual DbSet<StudentClass> StudentClass { get; set; }
        public virtual DbSet<SubjectBook> SubjectBook { get; set; }
        public virtual DbSet<SubjectNames> SubjectNames { get; set; }
        public virtual DbSet<TeacherClassSubject> TeacherClassSubject { get; set; }
    }
}