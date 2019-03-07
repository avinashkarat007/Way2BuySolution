using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Way2Buy.BusinessObjects.Entities
{
    public class Review
    {
        public int ReviewId { get; set; }

        public string ReviewComment { get; set; }

        public DateTime ReviewDate { get; set; }
    }
}
