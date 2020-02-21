using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SMP.app.Models
{
    public class AspNetUser
    {
        public string Id { get; set; }
        public int taskid { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Role")]
        public int RoleId { get; set; }
        [Display(Name = "Force Password")]
        public bool ForcePassword { get; set; }
        [Display(Name = "Is Approved")]
        public bool IsApproved { get; set; }
        public Nullable<System.DateTime> LastLoginDate { get; set; }
        public Nullable<System.DateTime> LastLogoutDate { get; set; }
        public bool LoggedOn { get; set; }
        public string MobileNo { get; set; }
        public Nullable<System.DateTime> PasswordExpiryDate { get; set; }
        public Nullable<System.DateTime> DateCreated { get; set; }
        public string Status { get; set; }
        public Nullable<int> EnforcePasswordChangeDays { get; set; }
        public Nullable<System.DateTime> LastPasswordChangeDate { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public bool IsSupervisor { get; set; }
        public Nullable<int> SupervisorId { get; set; }
        public string Email { get; set; }
        public bool EmailConfirmed { get; set; }
        public string PasswordHash { get; set; }
        public string SecurityStamp { get; set; }
        public string PhoneNumber { get; set; }
        public bool PhoneNumberConfirmed { get; set; }
        public bool TwoFactorEnabled { get; set; }
        public Nullable<System.DateTime> LockoutEndDateUtc { get; set; }
        public bool LockoutEnabled { get; set; }
        public int AccessFailedCount { get; set; }
        public string UserName { get; set; }
        public int UserId { get; set; }
    }
}