using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SMP.app.Models
{
    public class Campus
    {
        public int ItbId { get; set; }
        public int taskid { get; set; }
        [Display(Name = "Campus")]
        public string Name { get; set; }
        [Display(Name = "Address")]
        public string Address { get; set; }

        [Display(Name = "Division")]
        public int DivisionId { get; set; }

        [Display(Name = "Contact Person")]
        public string Contact_Person { get; set; }
        [Display(Name = "Contact Email")]
        public string Contact_Email { get; set; }
        [Display(Name = "Contact Mobile")]
        public string Contact_MobileNo { get; set; }
        [Display(Name = "School Name")]
        public Nullable<int> SchoolId { get; set; }
        [Display(Name = " Campus Image")]
        public string ImageUrl { get; set; }
        public Nullable<System.DateTime> Last_Modified_Date { get; set; }
        public string Last_Modified_Authid { get; set; }
        public string Last_Modified_Uid { get; set; }
        public string Status { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
    }
}