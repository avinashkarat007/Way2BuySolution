using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Way2Buy.BusinessObjects.Entities;

namespace Way2Buy.Models
{
    public class ProductViewModel
    {
        public Product Product { get; set; }

        [Display(Name = "Select the category")]
        public List<Category> Categories { get; set; }
    }
}