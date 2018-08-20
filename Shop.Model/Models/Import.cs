﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Model.Models
{
    [Table("Imports")]
    public class Import
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        
        [Required]
        public DateTime? CreatedDate { get; set; }

        [Required]
        public string CreatedBy { get; set; }

        [Required]
        public DateTime? UpdatedDate { get; set; }

        [Required]
        public string UpdateddBy { get; set; }

        public bool Status { get; set; }

        [MaxLength(500)]
        public string Description { get; set; }

        public virtual IEnumerable<ImportDetail> ImportDetail { get; set; }
    }
}