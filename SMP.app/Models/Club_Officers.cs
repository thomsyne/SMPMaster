using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SMP.app.Models
{
    public class Club_Officers
    {
        public int ItbId { get; set; }
        public int taskid { get; set; }
        [Display(Name = "School")]
        public Nullable<int> SchoolId { get; set; }
        [Display(Name = "Student")]
        public Nullable<int> StudentId { get; set; }
        [Display(Name = "Club")]
        public Nullable<int> ClubId { get; set; }
        [Display(Name = "Club Membership")]
        public Nullable<int> Club_MemebershipId { get; set; }
        [Display(Name = "Position")]
        public string Position { get; set; }
        [Display(Name = "Session")]
        public Nullable<int> SessionId { get; set; }
        [Display(Name = "Term")]
        public Nullable<int> TermId { get; set; }
        [Display(Name = "Program")]
        public Nullable<int> ProgramId { get; set; }
        [Display(Name = "Effecture Date")]
        public Nullable<System.DateTime> Effecture_Date { get; set; }
        [Display(Name = "Terminal Date")]
        public Nullable<System.DateTime> Terminal_Date { get; set; }
        public Nullable<System.DateTime> Last_Modified_Date { get; set; }
        public string Last_Modified_Authid { get; set; }
        public string Last_Modified_Uid { get; set; }
        public string Status { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
    }
}