using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Way2Buy.HTMLHelpers
{
    public class PageInfo
    {
        public int TotalItems { get; set; }
        public int ItemsPerPage { get; set; } = 5;
        public int CurrentPage { get; set; } = 1;

        public int TotalPages
        {
            get { return (int)Math.Ceiling((decimal)TotalItems / ItemsPerPage); }
        }
    }
}