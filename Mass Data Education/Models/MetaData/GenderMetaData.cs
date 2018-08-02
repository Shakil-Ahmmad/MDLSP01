using System.ComponentModel.DataAnnotations;

namespace Mass_Data_Education.Models
{
    public class GenderMetaData
    {
        [Display(Name = "Gender Name"), Required(ErrorMessage = "Please Provide Gender Name")]
        [StringLength(20), MinLength(3), MaxLength(20)]
        public string Name { get; set; }
    }

    [MetadataType(typeof(GenderMetaData))]
    public partial class Gender { }
}