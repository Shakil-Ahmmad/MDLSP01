using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Mass_Data_Education.Models
{
    public class SubjectBookMetaData
    {
        [Display(Name = "Book Name")]
        public string Name { get; set; }
        
        public string Writer { get; set; }
    }
    [MetadataType(typeof(SubjectBookMetaData))]
    public partial class SubjectBook { }
}