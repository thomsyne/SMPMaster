using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SMP.app.Models
{
    public class Currency
    {
        public int ItbId { get; set; }
        public int taskid { get; set; }
        [Display(Name = "Code")]
        public string Currency_Code { get; set; }
        [Display(Name = "Currency")]
        public string Currency_Name { get; set; }
        [Display(Name = "ISO Code")]
        public string ISO_Code { get; set; }

        [Display(Name = "Country")]
        public int CountryId { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
        public string CreatedBy { get; set; }
        public string Status { get; set; }
        public Nullable<System.DateTime> Last_Modified_Date { get; set; }
        public string Last_Modified_Authid { get; set; }
        public string Last_Modified_Uid { get; set; }
    }
}