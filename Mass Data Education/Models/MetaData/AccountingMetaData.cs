using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Mass_Data_Education.Models
{
    public class AccountingMetaData
    {

        [Key]
        public int Id { get; set; }
        [Display(Name = "Person Id"), Required(ErrorMessage = "Please Provide a Value For This Field")]
        //[ForeignKey("StudentProfileModel")]
        public string PersonID { get; set; }
        [Display(Name = "PaidForMonth"), Required(ErrorMessage = "Please Provide a Value For This Field")]

        public string PaidForMonth { get; set; }
        [Display(Name = "PayDate"), Required(ErrorMessage = "Please Provide a Value For This Field")]

        public DateTime PayDate { get; set; }
        [Display(Name = "Amount"), Required(ErrorMessage = "Please Provide a Value For This Field")]

        public int Amount { get; set; }
        [Display(Name = "Paymant Names"), Required(ErrorMessage = "Please Provide a Value For This Field")]
        //[ForeignKey("PaymantNamesModel")]
        public int PaymantNamesId { get; set; }
    }
    [MetadataType(typeof(AccountingMetaData))]
    public partial class Accounting { }
}