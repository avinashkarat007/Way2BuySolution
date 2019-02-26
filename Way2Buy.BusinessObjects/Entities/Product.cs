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

        [Required]
        public double Price { get; set; }

        public double OfferPrice { get; set; }

        public byte[] ImageData { get; set; }
        public string ImageMimeType { get; set; }
    }
}
