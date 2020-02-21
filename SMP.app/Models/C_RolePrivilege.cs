using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SMP.app.Models
{
    public class C_RolePrivilege
    {
        public decimal ItbId { get; set; }
        public int taskid { get; set; }
        [Display(Name = "Menu")]
        public int MenuId { get; set; }
        [Display(Name = "Role")]
        public int RoleId { get; set; }
        public bool CanCreateNew { get; set; }
        public bool CanEdit { get; set; }
        public bool CanDelete { get; set; }
        public bool CanAuthorize { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> DateCreated { get; set; }
        public string Status { get; set; }
        public string CompanyCode { get; set; }
    }
}