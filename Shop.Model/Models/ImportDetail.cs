using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Model.Models
{
    [Table("ImportDetails")]
    public class ImportDetail
    {
        [Key]
        [Column(Order = 1)]
        public int ImportID { get; set; }

        [Key]
        [Column(Order = 2)]
        public int ProductID { get; set; }

        public string Quantity { get; set; }

        [ForeignKey("ProductID")]
        public virtual Product Product { get; set; }

        [ForeignKey("ImportID")]
        public virtual Import Import { get; set; }
    }
}
