using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shop.Model.Models
{
    [Table("Orders")]
    public class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required]
        [MaxLength(256)]
        public string CustomerName { get; set; }
        [Required]
        [MaxLength(256)]
        public string CustomerAddress { get; set; }
        [Required]
        [MaxLength(256)]
        public string CustomerEmail { get; set; }
        [Required]
        [MaxLength(256)]
        public string CustomerMobile { get; set; }
        
        [MaxLength(256)]
        public string CustomerMessage { get; set; }
        [Required]
        public DateTime CreatedDate { get; set; }
        [Required]
        public string CreatedBy { get; set; }
        
        [MaxLength(256)]
        public string PaymentMethod { get; set; }
        
        public string PaymentStatus { get; set; }

        
        public bool? Status { get; set; }

        [StringLength(128)]
        [Column(TypeName ="nvarchar")]
        public string CustomerId { get; set; }

        [ForeignKey("CustomerId")]
        public virtual ApplicationUser User { get; set; }

        public virtual IEnumerable<OrderDetail> OrderDetail { get; set; }
    }
}