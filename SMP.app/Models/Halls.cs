﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SMP.app.Models
{
    public class Halls
    {
        public int ItbId { get; set; }
        public int taskid { get; set; }
        [Display(Name = "School")]
        public Nullable<int> SchoolId { get; set; }
        [Display(Name = "Hall Name")]
        public string Hall_Name { get; set; }
        [Display(Name = "No Of Rooms")]
        public string No_Of_Rooms { get; set; }
        public Nullable<System.DateTime> Last_Modified_Date { get; set; }
        public string Last_Modified_Authid { get; set; }
        public string Last_Modified_Uid { get; set; }
        public string Status { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
    }
}