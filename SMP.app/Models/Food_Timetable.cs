using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SMP.app.Models
{
    public class Food_Timetable
    {
        public int ItbId { get; set; }
        public int taskid { get; set; }
        [Display(Name = "Menu Day")]
        public string Menu_Day { get; set; }
        [Display(Name = "Menu Type")]
        public Nullable<int> MenuTypeId { get; set; }

        [Display(Name = "Day")]
        public Nullable<int> Menu_DayId { get; set; }

        [Display(Name = "Start Time")]
        public Nullable<System.DateTime> Start_Time { get; set; }
        [Display(Name = "End Time")]
        public Nullable<System.DateTime> End_Time { get; set; }
        [Display(Name = "Menu Description")]
        public string Menu_Description { get; set; }
        public Nullable<System.DateTime> Last_Modified_Date { get; set; }
        public string Last_Modified_Authid { get; set; }
        public string Last_Modified_Uid { get; set; }
        public string Status { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
    }
}