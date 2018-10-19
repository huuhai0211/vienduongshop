using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shop.Web.Models
{
    public class WarehouseViewModel
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public string PhoneNumber { get; set; }

        public string Note { get; set; }

        public string Manager { get; set; }

        public DateTime? CreatedDate { get; set; }
        
        public string CreatedBy { get; set; }

        public DateTime? UpdatedDate { get; set; }
        
        public string UpdatedBy { get; set; }

        public bool Status { get; set; }

        public virtual IEnumerable<LocationViewModel> Locations { get; set; }
    }
}