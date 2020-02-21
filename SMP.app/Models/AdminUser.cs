using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SMP.app.Models
{
    public class AdminUser
    {
        public long ItbId { get; set; }
        public int taskid { get; set; }
        public int RoleID { get; set; }
        public string Username { get; set; }
        public string Surname { get; set; }
        [Display(Name = "First Name")]
        public string Firstname { get; set; }
        public string Email { get; set; }
        [Display(Name = "Phone Number")]
        public string Telephone { get; set; }
        public System.DateTime LastLogin { get; set; }
        public bool IsActive { get; set; }
        public bool IsFirstLogin { get; set; }
        public int FailedLogins { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> DateCreated { get; set; }
        public Nullable<bool> IsApproved { get; set; }
        public Nullable<long> ApprovedBy { get; set; }
        public Nullable<System.DateTime> DateApproved { get; set; }
        public Nullable<bool> IsTokenRequired { get; set; }
        public Nullable<decimal> LimitAmount { get; set; }
        public bool IsDeleted { get; set; }
    }
}