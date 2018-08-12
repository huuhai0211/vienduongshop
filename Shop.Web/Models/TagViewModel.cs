﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shop.Web.Models
{
    public class TagViewModel
    {
        public string ID { get; set; }

   
        public string Name { get; set; }

     
        public string Type { get; set; }

        public virtual IEnumerable<PostTagViewModel> PostTags { get; set; }

        public virtual IEnumerable<ProductTagViewModel> ProductTags { get; set; }
    }
}