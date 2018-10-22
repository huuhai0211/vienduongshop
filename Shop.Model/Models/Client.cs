using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shop.Model.Models
{
    [Table("Clients")]
    public class Client
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }

        public string Gender { get; set; }

        public DateTime Birthday { get; set; }

        [Required]
        public string Address { get; set; }

        public int Phone_Number { get; set; }

        public string Email { get; set; }

        public string Note { get; set; }

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

