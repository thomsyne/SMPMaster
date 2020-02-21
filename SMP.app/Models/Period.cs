using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SMP.app.Models
{
    public class Period
    {
        public int ItbId { get; set; }
        public int taskid { get; set; }
        [Display(Name = "Period")]
        public string Name { get; set; }

        [Display(Name = "Day")]
        public Nullable<int> DayId { get; set; }

        [Display(Name = "Start Time")]
        public Nullable<System.TimeSpan> Start_Time { get; set; }
        [Display(Name = "End Time")]
        public Nullable<System.TimeSpan> End_Time { get; set; }


        public Nullable<System.DateTime> Last_Modified_Date { get; set; }
        public string Last_Modified_Authid { get; set; }
        public string Last_Modified_Uid { get; set; }
        public string Status { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
    }
}