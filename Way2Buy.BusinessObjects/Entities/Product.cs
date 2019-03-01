using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Way2Buy.BusinessObjects.Entities
{
    public class Product
    {
        public int ProductId { get; set; }

        [Required(ErrorMessage = "Enter the product name")]
        public string Name { get; set; }

        public string Description { get; set; }

        [Required(ErrorMessage = "Enter the product price")]
        public double Price { get; set; }

        public bool IsOfferItem { get; set; }

        public double OfferPrice { get; set; }

        [Required]
        public byte[] ImageData { get; set; }
        public string ImageMimeType { get; set; }
    }
}
