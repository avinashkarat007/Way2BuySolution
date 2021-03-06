﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using Way2Buy.BusinessObjects.Helpers;

namespace Way2Buy.BusinessObjects.Entities
{
    public class Product
    {
        [Key]        
        public int ProductId { get; set; }

        [Required(ErrorMessage = "Enter the product name")]
        [RegularExpression(@"^([a-zA-Z]+)$", ErrorMessage = "Please enter a valid name.")]
        public string Name { get; set; }

        public string Description { get; set; }

        [Required(ErrorMessage = "Enter the product price")]
        [RegularExpression(@"^([\d]+)$",ErrorMessage = "Please enter numeric values only.")]
        public double Price { get; set; }

        public bool IsOfferItem { get; set; }

        [RequiredIf("IsOfferItem",true, ErrorMessage = "Please enter the offer price")]
        public double? OfferPrice { get; set; }

        [Required(ErrorMessage = "Please upload an image")]
        public byte[] ImageData { get; set; }
        public string ImageMimeType { get; set; }       

        [Required(ErrorMessage = "Please select a category")]
        public int CategoryId { get; set; }

        public List<Review> Reviews { get; set; }
    }
}
