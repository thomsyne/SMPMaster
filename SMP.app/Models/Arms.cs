using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SMP.app.Models
{
    public class Arms
    {
        public int ItbId { get; set; }
        public int taskid { get; set; }
        [Display(Name = "Name")]
        public string Name { get; set; }
        [Display(Name = "School")]
        public Nullable<int> SchoolId { get; set; }
        [Display(Name = "Class")]
        public Nullable<int> ClassId { get; set; }
        [Display(Name = "Program")]
        public int ProgramId { get; set; }
        [Display(Name = "Campus")]
        public int CampusId { get; set; }
        
        [Display(Name = "Staff Type")]
        public int Staff_TypeId { get; set; }

        [Display(Name = "Class Teacher")]
        public Nullable<int> ClassTeacherId { get; set; }

        [Display(Name = "Class Teacher")]
        public Nullable<int> Staff { get; set; }

        [Display(Name = "No Of Student")]
        public Nullable<int> No_Of_Student { get; set; }
        [Display(Name = "Max Student")]
        public Nullable<int> Max_No_Of_Student { get; set; }
        public Nullable<System.DateTime> Last_Modified_Date { get; set; }
        public string Last_Modified_Authid { get; set; }
        public string Last_Modified_Uid { get; set; }
        public string Status { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
    }
}