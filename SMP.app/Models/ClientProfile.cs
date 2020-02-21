using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SMP.app.Models
{
    public class ClientProfile
    {
        public int ItbId { get; set; }
        public int taskid { get; set; }

        [Display(Name = "Bank Code")]
        public string BankCode { get; set; }
        [Display(Name = "Bank Name")]
        public string BankName { get; set; }

        [Display(Name = "Bank Address")]
        public string BankAddress { get; set; }

        [Display(Name = "Idle Timeout")]
        public int SystemIdleTimeout { get; set; }

        [Display(Name = "Login Count")]
        public int LoginCount { get; set; }

        [Display(Name = "Set User")]
        public int SetUserViaWebService { get; set; }

        public string Last_Modified_Authid { get; set; }
        public string Last_Modified_Uid { get; set; }
        public string Status { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
    }
}