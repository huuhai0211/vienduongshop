﻿using Shop.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shop.Web.Models
{
    public class ContributorViewModel
    {
        public int ID_Business { get; set; }

        public string Name { get; set; }
        public string Alias { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public int Phone_Number { get; set; }
        public string Email { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }

        public bool Status { get; set; }

        public virtual IEnumerable<ProductViewModel> Products { get; set; }



    }
}