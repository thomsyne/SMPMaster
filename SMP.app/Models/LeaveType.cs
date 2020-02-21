using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SMP.app.Models
{
    public class LeaveType
    {
        public int ItbId { get; set; }
        public int taskid { get; set; }

        [Display(Name = "Description")]
        public string Description { get; set; }

        [Display(Name = "Minimum Number of Days")]
        public string Min_Day { get; set; }

        [Display(Name = "Maximum Number of Days")]
        public string Max_Day { get; set; }

        public Nullable<System.DateTime> Last_Modified_Date { get; set; }
        public string Last_Modified_Authid { get; set; }
        public string Last_Modified_Uid { get; set; }
        public string Status { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
    }
}