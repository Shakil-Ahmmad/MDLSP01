using System.Collections.Generic;
using Mass_Data_Education.Models;
using System.ComponentModel.DataAnnotations;
using System;

namespace Mass_Data_Education.Models.ViewModel
{
    public class ClassSubjectVM
    {
        public int Id { get; set; }

        [Display(Name = "Class")]
        [Required]
        public int ClassId { get; set; }
        
        public string ClassName { get; set; }

        [Display(Name = "Subject")]
        [Required]
        public string SubjectNames { get; set; }

        public List<SubjectBook> SubjectBooks { get; set; }

        public string Books
        {
            get
            {
                string data = "";
                foreach (var item in SubjectBooks)
                {
                    if (item.Writer != null)
                    {
                        data += item.Name + " | Author: " + item.Writer + Environment.NewLine;
                    }
                    else
                    {
                        data += item.Name + Environment.NewLine;
                    }
                }
                return data;
            }
        }
    }
}