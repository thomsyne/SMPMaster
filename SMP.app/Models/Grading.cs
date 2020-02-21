using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SMP.app.Models
{
    public class Grading
    {
        public int ItbId { get; set; }
        public int taskid { get; set; }
        [Display(Name = "Code")]
        public string Code { get; set; }
        [Display(Name = "Description")]
        public string Description { get; set; }
        [Display(Name = "Grade Min")]
        public Nullable<int> Grade_Min { get; set; }
        [Display(Name = "Grade Max")]
        public Nullable<int> Grade_Max { get; set; }
        [Display(Name = "Exam Type")]
        public Nullable<int> Exam_TypeId { get; set; }
        [Display(Name = "School")]
        public Nullable<int> SchoolId { get; set; }
        public Nullable<System.DateTime> Last_Modified_Date { get; set; }
        public string Last_Modified_Authid { get; set; }
        public string Last_Modified_Uid { get; set; }
        public string Status { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
    }
}