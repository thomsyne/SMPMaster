using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SMP.app.Models
{
    public class School_Bus
    {
        public int ItbId { get; set; }
        public int taskid { get; set; }
        [Display(Name = "School")]
        public Nullable<int> SchoolId { get; set; }
        [Display(Name = "School Bus")]
        public string Name { get; set; }
        [Display(Name = "Route")]
        public Nullable<int> RouteId { get; set; }
        [Display(Name = "Driver")]
        public string Driver_Name { get; set; }
        [Display(Name = "Driver's Phone No")]
        public int Driver_Phone_No { get; set; }
        [Display(Name = "Price")]
        public string Price { get; set; }
        public Nullable<System.DateTime> Last_Modified_Date { get; set; }
        public string Last_Modified_Authid { get; set; }
        public string Last_Modified_Uid { get; set; }
        public string Status { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
    }
}