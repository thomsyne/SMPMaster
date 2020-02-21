using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SMP.app.Models
{
    public class AspNetUserLogin
    {
        public string LoginProvider { get; set; }
        public int id { get; set; }
        public int taskid { get; set; }
        public string ProviderKey { get; set; }
        public string UserId { get; set; }

        public virtual AspNetUser AspNetUser { get; set; }
    }
}