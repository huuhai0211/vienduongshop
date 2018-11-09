﻿using Shop.Model.Abstract;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace Shop.Model.Models
{
    [Table("Products")]
    public class Product : Auditable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required]
        [MaxLength(256)]
        public string Name { get; set; }

        [Required]
        [Column(TypeName = "varchar")]
        [MaxLength(256)]
        public string Alias { get; set; }

        [Required]
        public int CategoryID { get; set; }

    //    [Required] THÊM SAU
        public int?  BusinessID { get; set; }


        [MaxLength(256)]
        public string Image { get; set; }

        [Column(TypeName = "xml" )]
        public string MoreImage { get; set; }
        public decimal Price { get; set; }
        public decimal? PromotionPrice { get; set; }
        public int? Warranty { get; set; }

        [MaxLength(500)]
        public string Description { get; set; }
        public string Content { get; set; }
        public bool? HomeFlag { get; set; }
        public bool? HotFlag { get; set; }
        public int? ViewCount { get; set; }

        public string Tags { get; set; }

        //public int Quantity { get; set; }

        //public decimal OriginalPrice { get; set; }

        [ForeignKey("CategoryID")]
        public virtual ProductCategory ProductCategory { get; set; }

        public virtual IEnumerable<OrderDetail> OrderDetails { get; set; }

        public virtual IEnumerable<ProductTag> ProductTags { get; set; }
        
        [ForeignKey("BusinessID")]
        public virtual Contributor Contributors { get; set; }

        public virtual IEnumerable<Location> Locations { get; set; }
    }
}
//sao lại có ClientID ở bên Product thế? của cái cũ, xem khách mua hàng gì ấy
