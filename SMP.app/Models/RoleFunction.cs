using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SMP.app.Models
{
    public class RoleFunction
    {
        public long ID { get; set; }
        public int taskid { get; set; }
        [Display(Name = "Role")]
        public Nullable<long> RoleID { get; set; }
        [Display(Name = "Function")]
        public Nullable<long> FunctionID { get; set; }
        public Nullable<long> CreatedBy { get; set; }
        public Nullable<System.DateTime> DateCreated { get; set; }
    }
}