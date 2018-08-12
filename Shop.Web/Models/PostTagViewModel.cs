using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shop.Web.Models
{
    public class PostTagViewModel
    {
        public string TagID { get; set; }

    
        public int PostID { get; set; }

       
        public virtual PostViewModel Post { get; set; }

      
        public virtual TagViewModel Tag { get; set; }
    }
}