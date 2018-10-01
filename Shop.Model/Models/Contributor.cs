using Shop.Model.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shop.Model.Models
{
    [Table("Contributors")]
    public class Contributor
    {
        [Key]
        public int ID_Business { get; set; }

        [Required]     
        public string Name { get; set; }

        [Required]
        [Column(TypeName = "varchar")]
        public string Alias { get; set; }

        [MaxLength(500)]
        public string Description { get; set; }

        [Required]
        public string Address { get; set; }

        public int Phone_Number { get; set; }

        public string Email { get; set; }

        public DateTime? CreatedDate { get; set; }

        [MaxLength(256)]
        public string CreatedBy { get; set; }

        public DateTime? UpdatedDate { get; set; }

        [MaxLength(256)]
        public string UpdatedBy { get; set; }

        public bool Status { get; set; }

        public virtual IEnumerable<Product> Products { get; set; }
    }
}

