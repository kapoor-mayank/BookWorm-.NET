
using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;

namespace BookWorm.Models
{
    public class PublisherMaster
    {
        [Key]
        public long publisherId { get; set; }

        public String publisherName { get; set; }

        public String publisherContactNo { get; set; }
    }
}
