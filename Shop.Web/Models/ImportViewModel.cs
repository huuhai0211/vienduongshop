using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shop.Web.Models
{
    public class ImportViewModel
    {
        public int ID { get; set; }
        
        public DateTime? CreatedDate { get; set; }
        
        public string CreatedBy { get; set; }
        
        public DateTime? UpdatedDate { get; set; }
        
        public string UpdatedBy { get; set; }

        public bool Status { get; set; }
        
        public string Description { get; set; }

        public virtual IEnumerable<ImportDetailViewModel> ImportDetail { get; set; }
    }
}