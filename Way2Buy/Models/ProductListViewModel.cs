using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Way2Buy.BusinessObjects.Entities;
using Way2Buy.HTMLHelpers;

namespace Way2Buy.Models
{
    public class ProductListViewModel
    {
        public IEnumerable<Product> Products { get; set; }

        public PageInfo PageInfo { get; set; }
    }

    public enum PageCount
    {       
       Five,
       Ten,
       Fifteen
    }
}