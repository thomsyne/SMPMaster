using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SMP.app.Models
{
    public class Mis_Behavior
    {
        public int ItbId { get; set; }
        public int taskid { get; set; }
        [Display(Name = "School")]
        public Nullable<int> SchoolId { get; set; }
        [Display(Name = "Class")]
        public Nullable<int> ClassId { get; set; }
        [Display(Name = "Arm")]
        public Nullable<int> ArmId { get; set; }
        [Display(Name = "Student")]
        public Nullable<int> StudentId { get; set; }
        [Display(Name = "Program")]
        public Nullable<int> ProgramId { get; set; }
        [Display(Name = "Session")]
        public Nullable<int> SessionId { get; set; }
        [Display(Name = "Term")]
        public Nullable<int> TermId { get; set; }
        [Display(Name = "Details")]
        public string Details { get; set; }

        [Display(Name = "Date")]
        public Nullable<System.TimeSpan> Date_Misbehavior { get; set; }

        [Display(Name = "Reporter User")]
        public string Reporter_User { get; set; }
        [Display(Name = "Is Resolved")]
        public string Is_Resolved { get; set; }
        public Nullable<System.DateTime> Last_Modified_Date { get; set; }
        public string Last_Modified_Authid { get; set; }
        public string Last_Modified_Uid { get; set; }
        public string Status { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
    }
}