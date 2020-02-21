using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SMP.app.Models
{
    public class Attendance_Staff
    {
        public int ItbId { get; set; }
        public int taskid { get; set; }
        [Display(Name = "School")]
        public Nullable<int> SchoolId { get; set; }
        [Display(Name = "Register Status")]
        public Nullable<int> Register_StatusId { get; set; }
        [Display(Name = "Reason For Absence")]
        public string Reason_For_Absence { get; set; }
        [Display(Name = "Attendance Date")]
        public Nullable<System.DateTime> Attendance_Date { get; set; }
        [Display(Name = "Attendance Month")]
        public string Attendance_Month { get; set; }
        public Nullable<System.DateTime> Last_Modified_Date { get; set; }
        public string Last_Modified_Authid { get; set; }
        public string Last_Modified_Uid { get; set; }
        public string Status { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
    }
}