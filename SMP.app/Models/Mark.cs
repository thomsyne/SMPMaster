using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SMP.app.Models
{
    public class Mark
    {
        public int ItbId { get; set; }
        public int taskid { get; set; }
        [Display(Name = "School")]
        public Nullable<int> SchoolId { get; set; }
        [Display(Name = "Student Code")]
        public string StudentId { get; set; }
        [Display(Name = "Class")]
        public Nullable<int> ClassId { get; set; }
        [Display(Name = "Subject")]
        public Nullable<int> SubjectId { get; set; }
        [Display(Name = "Session")]
        public Nullable<int> SessionId { get; set; }
        [Display(Name = "Term")]
        public Nullable<int> TermId { get; set; }
        [Display(Name = "Arms")]
        public Nullable<int> ArmId { get; set; }
        [Display(Name = "Program")]
        public Nullable<int> ProgramId { get; set; }
        [Display(Name = "CA Score 1")]
        public string CA_Score1 { get; set; }
        [Display(Name = "CA Score 2")]
        public string CA_Score2 { get; set; }
        [Display(Name = "CA Score 3")]
        public string CA_Score3 { get; set; }
        [Display(Name = "CA Score 4")]
        public string CA_Score4 { get; set; }
        [Display(Name = "CA Score 5")]
        public string CA_Score5 { get; set; }
        [Display(Name = "Exam Score")]
        public string Exam_Score { get; set; }
        [Display(Name = "Exam Type")]
        public Nullable<int> Exam_TypeId { get; set; }
        public Nullable<System.DateTime> Last_Modified_Date { get; set; }
        public string Last_Modified_Authid { get; set; }
        public string Last_Modified_Uid { get; set; }
        public string Status { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
    }
}