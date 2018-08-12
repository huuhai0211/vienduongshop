using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shop.Web.Models
{
    public class OrderDetailViewModel
    {
        public int OrderID { get; set; }

        public int ProductID { get; set; }

        public string Quantity { get; set; }

       
        public virtual ProductViewModel Product { get; set; }

        public virtual OrderViewModel Order { get; set; }
    }
}