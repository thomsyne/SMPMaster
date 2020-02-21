using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SMP.app.Models
{
    public class StaffAllowanceSetup
    {
        public int ItbId { get; set; }
        public int taskid { get; set; }

        [Display(Name = "Level")]
        public Nullable<int> LevelId { get; set; }

        [Display(Name = "Allowance")]
        public Nullable<int> AllowanceId { get; set; }

        [Display(Name = "Amount")]
        public Nullable<decimal> Amount { get; set; }
        public Nullable<System.DateTime> Last_Modified_Date { get; set; }
        public string Last_Modified_Authid { get; set; }
        public string Last_Modified_Uid { get; set; }
        public string Status { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }

    }
}