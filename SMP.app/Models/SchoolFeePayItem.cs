using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SMP.app.Models
{
    public class SchoolFeePayItem
    {
        public int taskid { get; set; }
        public int ItbId { get; set; }
        public string PayCode { get; set; }
        public string PayItemDesc { get; set; }
        public string Compulsory { get; set; }
        public bool Taxable { get; set; }
        public string PaymentFrequency { get; set; }
        public string CalculationBasis { get; set; }
        public Nullable<decimal> Rate { get; set; }
        public string RefPayCode { get; set; }
        public string GLAcctNo { get; set; }
        public Nullable<System.DateTime> Last_Modified_Date { get; set; }
        public string Last_Modified_Authid { get; set; }
        public string Last_Modified_Uid { get; set; }
        public string Status { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
    }
}