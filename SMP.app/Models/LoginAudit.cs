using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SMP.app.Models
{
    public class LoginAudit
    {
        public int ItbId { get; set; }
        public int taskid { get; set; }

        [Display(Name = "Processing Date")]
        public Nullable<System.DateTime> ProcessingDate { get; set; }
        [Display(Name = "User ID")]
        public Nullable<int> UserId { get; set; }

        [Display(Name = "Login Date")]
        public Nullable<System.DateTime> LoginDate { get; set; }
        [Display(Name = "Logout Date")]
        public Nullable<System.DateTime> LogoutDate { get; set; }

        [Display(Name = "Mac Address")]
        public string MacAddress { get; set; }

        public string Last_Modified_Authid { get; set; }
        public string Last_Modified_Uid { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
    }
}