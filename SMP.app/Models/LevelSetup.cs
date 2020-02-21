using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SMP.app.Models
{
    public class LevelSetup
    {
        public int ItbId { get; set; }
        public int taskid { get; set; }

        [Display(Name = "Level")]
        public string HR_Level { get; set; }
        [Display(Name = "Basic Salary")]
        public Nullable<decimal> Basic_Salary { get; set; }
        public Nullable<System.DateTime> Last_Modified_Date { get; set; }
        public string Last_Modified_Authid { get; set; }
        public string Last_Modified_Uid { get; set; }
        public string Status { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
    }
}