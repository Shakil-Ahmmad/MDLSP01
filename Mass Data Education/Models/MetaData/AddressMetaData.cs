using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Mass_Data_Education.Models
{
    public class AddressMetaData
    {
        [Display(Name = "Address"), Required(ErrorMessage = "Please Provide a Value For This Field")]
        public string Name { get; set; }
        [Display(Name = "Address"), Required(ErrorMessage = "Please Provide a Value For This Field")]
        public Nullable<int> AddressID { get; set; }

    }

    [MetadataType(typeof(AddressMetaData))]
    public partial class Address { }

}