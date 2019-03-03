using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Way2Buy.BusinessObjects.Entities;

namespace Way2Buy.Models
{
    public class ProductViewModel
    {
        public Product Product { get; set; }

        public List<Category> Categories { get; set; }
    }
}