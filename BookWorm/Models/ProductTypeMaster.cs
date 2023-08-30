using System.ComponentModel.DataAnnotations;

namespace ProductTypeMasterWorm.Models
{
    public class ProductTypeMaster
    {
        [Key]
        public long typeId { get; set; }

        [Required (ErrorMessage ="Product TypeDesc required")]
        public string typeDesc { get; set; }
        
    }
}
