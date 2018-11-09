using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shop.Web.Models
{
    public class ImportDetailViewModel
    {
        public int ImportID { get; set; }
        
        public int ProductID { get; set; }

        public int WarehouseId { get; set; }

        public string Quantity { get; set; }

        public decimal Price { get; set; }

        public virtual ProductViewModel Product { get; set; }
        
        public virtual ImportViewModel Import { get; set; }
    }
}