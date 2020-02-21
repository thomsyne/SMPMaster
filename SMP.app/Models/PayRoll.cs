using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SMP.app.Models
{
    public class PayRoll
    {
        public int ItbId { get; set; }
        public int taskid { get; set; }

        [Display(Name = "Staff")]
        public Nullable<int> StaffId { get; set; }

        [Display(Name = "Dept ID")]
        public Nullable<int> DeptId { get; set; }

        [Display(Name = "Deduction")]
        public Nullable<int> DeductionId { get; set; }

        [Display(Name = "Pay Date")]
        public Nullable<System.DateTime> Pay_Date { get; set; }

        [Display(Name = "Batch")]
        public string BatchId { get; set; }

        [Display(Name = "Salary")]
        public Nullable<decimal> Salary { get; set; }

        public Nullable<System.DateTime> Last_Modified_Date { get; set; }
        public string Last_Modified_Authid { get; set; }
        public string Last_Modified_Uid { get; set; }
        public string Status { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
    }
}