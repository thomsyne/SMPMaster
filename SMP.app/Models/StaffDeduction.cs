using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SMP.app.Models
{
    public class StaffDeduction
    {
        public int ItbId { get; set; }
        public int taskid { get; set; }

        [Display(Name = "Deduction")]
        public Nullable<int> DeductionId { get; set; }

        [Display(Name = "Staff")]
        public Nullable<int> StaffId { get; set; }

        [Display(Name = "Amount")]
        public Nullable<decimal> Amount { get; set; }

        [Display(Name = "Rate Type")]
        public string RateType { get; set; }

        [Display(Name = "Frequency")]
        public Nullable<int> Frequency { get; set; }

        [Display(Name = "Actual Amount")]
        public Nullable<decimal> ActualAmount { get; set; }

        [Display(Name = "Start")]
        public Nullable<System.DateTime> Deduction_Start { get; set; }

        [Display(Name = "End")]
        public Nullable<System.DateTime> Deduction_End { get; set; }
        public Nullable<System.DateTime> Last_Modified_Date { get; set; }
        public string Last_Modified_Authid { get; set; }
        public string Last_Modified_Uid { get; set; }
        public string Status { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
    }
}