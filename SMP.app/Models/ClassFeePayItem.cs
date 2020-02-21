using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SMP.app.Models
{   
    public class ClassFeePayItem
    {
        public int taskid { get; set; }
        public int ItbId { get; set; }
        [Display(Name = "Pay Code")]
        public string PayCode { get; set; }
        [Display(Name = "Class")]
        public int ClassId { get; set; }
        [Display(Name = "Day Student Amount")]
        public Nullable<decimal> DAYStudentAmount { get; set; }
        [Display(Name = "Hostel Student Amount")]
        public Nullable<decimal> HostelStudentAmount { get; set; }
        public Nullable<System.DateTime> Last_Modified_Date { get; set; }
        public string Last_Modified_Authid { get; set; }
        public string Last_Modified_Uid { get; set; }
        public string Status { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
    }
}
