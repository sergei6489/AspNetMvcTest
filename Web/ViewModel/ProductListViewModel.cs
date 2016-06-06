using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Core;

namespace Web.ViewModel
{
    public class ProductListViewModel
    {
        public List<Product> Products { get; set; }
        public Dictionary<string, bool> Categories { get; set; }
    }
}