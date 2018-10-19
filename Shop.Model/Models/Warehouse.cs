using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Model.Models
{
    [Table("Warehouses")]
    public class Warehouse
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        
        public string Address { get; set; }

        public string PhoneNumber { get; set; }

        public string Note { get; set; }

        public string Manager { get; set; }

        public DateTime? CreatedDate { get; set; }

        [MaxLength(256)]
        public string CreatedBy { get; set; }

        public DateTime? UpdatedDate { get; set; }

        [MaxLength(256)]
        public string UpdatedBy { get; set; }

        public bool Status { get; set; }

        public virtual IEnumerable<Location> Locations { get; set; }
    }
}
