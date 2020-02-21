using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SMP.app.Models
{
    public class Prefect
    {
        public int ItbId { get; set; }
        public int taskid { get; set; }
        [Display(Name = "Campus")]
        public Nullable<int> CampusId { get; set; }
        [Display(Name = "Code")]
        public string Prefect_Code { get; set; }
        [Display(Name = "Prefect Role")]
        public string Prefect_Role { get; set; }
        public Nullable<System.DateTime> Last_Modified_Date { get; set; }
        public string Last_Modified_Authid { get; set; }
        public string Last_Modified_Uid { get; set; }
        public string Status { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
    }
}