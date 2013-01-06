using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bookwarm.Models
{
    public class Reading
    {
        public string UserName { get; set; }
        public int PageNumber { get; set; }
        public string Title { get; set; }
    }
}