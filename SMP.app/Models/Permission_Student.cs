using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SMP.app.Models
{
    public class Permission_Student
    {
        public int ItbId { get; set; }
        public int taskid { get; set; }
        [Display(Name = "School")]
        public Nullable<int> SchoolId { get; set; }
        [Display(Name = "Class")]
        public Nullable<int> ClassId { get; set; }
        [Display(Name = "Arms")]
        public Nullable<int> ArmId { get; set; }
        [Display(Name = "Student")]
        public Nullable<int> StudentId { get; set; }
        [Display(Name = "Program")]
        public Nullable<int> ProgramId { get; set; }
        [Display(Name = "Session")]
        public Nullable<int> SessionId { get; set; }
        [Display(Name = "Term")]
        public Nullable<int> TermId { get; set; }
        [Display(Name = "Permission Sought")]
        public string Permission_Sought { get; set; }
        [Display(Name = "Details")]
        public string Details { get; set; }
        [Display(Name = "Priority")]
        public string Priority { get; set; }
        [Display(Name = "Support Filepath")]
        public byte[] Supporting_Filepath { get; set; }
        [Display(Name = "Approval Status")]
        public string Approval_Status { get; set; }

        public Nullable<System.DateTime> Last_Modified_Date { get; set; }
        public string Last_Modified_Authid { get; set; }
        public string Last_Modified_Uid { get; set; }
        public string Status { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
    }
}