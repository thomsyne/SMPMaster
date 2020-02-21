using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SMP.app.Models
{
    public class LeaveSetup
    {
        public int ItbId { get; set; }
        public int taskid { get; set; }
        [Display(Name = "Staff")]
        public Nullable<int> StaffId { get; set; }
        [Display(Name = "Leave Type")]
        public Nullable<int> LeaveTypeId { get; set; }
        [Display(Name = "Leave Start")]
        public Nullable<System.DateTime> LeaveStart { get; set; }
        [Display(Name = "Leave End")]
        public Nullable<System.DateTime> LeaveEnd { get; set; }
        public Nullable<System.DateTime> Last_Modified_Date { get; set; }
        public string Last_Modified_Authid { get; set; }
        public string Last_Modified_Uid { get; set; }
        public string Status { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
    }
}