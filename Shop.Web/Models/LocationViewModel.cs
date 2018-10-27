using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shop.Web.Models
{
    public class LocationViewModel
    {
        public int ID { get; set; }
        
        public string Name { get; set; }

        public int WarehouseID { get; set; } //khác tên này

        public int ProductID { get; set; }

        public int MaximumQuantity { get; set; }

        public string Note { get; set; }

        public DateTime? CreatedDate { get; set; }
        
        public string CreatedBy { get; set; }

        public DateTime? UpdatedDate { get; set; }
        
        public string UpdatedBy { get; set; }

        public bool Status { get; set; }
        
        public virtual ProductViewModel Product { get; set; }
    }
}