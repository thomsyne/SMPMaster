using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SMP.app.Models
{
    public class Division
    {
        public int ItbId { get; set; }
        public int taskid { get; set; }
        [Display(Name = "Code")]
        public string Division_Code { get; set; }
        [Display(Name = "Division")]
        public string Division_Name { get; set; }
        [Display(Name = "State")]
        public Nullable<int> StateId { get; set; }
        public Nullable<System.DateTime> Last_Modified_Date { get; set; }
        public string Last_Modified_Authid { get; set; }
        public string Last_Modified_Uid { get; set; }
        public string Status { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
    }
}