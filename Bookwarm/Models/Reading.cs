using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bookwarm.Models
{
    public class Reading : Entity
    {
        public virtual string UserName { get; set; }
        public virtual int PageNumber { get; set; }
        public virtual string Title { get; set; }
        public virtual DateTime? LastUpdate { get; set; }
    }
}