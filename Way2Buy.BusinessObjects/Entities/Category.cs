using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Way2Buy.BusinessObjects.Entities
{
    public class Category
    {
        public int CategoryId { get; set; }

        [Required]
        public string CategoryName { get; set; }

        public string CategoryDescription { get; set; }

        public bool IsActive { get; set; }
    }
}
