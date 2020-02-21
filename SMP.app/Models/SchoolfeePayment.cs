using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SMP.app.Models
{
    public class SchoolfeePayment
    {
        public int taskid { get; set; }
        public long itbid { get; set; }
        public Nullable<int> ClassID { get; set; }
        public Nullable<int> ArmID { get; set; }
        public Nullable<int> StudentID { get; set; }
        public Nullable<int> StudentType { get; set; }
        public Nullable<int> Paycode { get; set; }
        public string PayItemDesc { get; set; }
        public Nullable<decimal> Amount { get; set; }
        public Nullable<decimal> AmountPaid { get; set; }
        public Nullable<decimal> AmountDue { get; set; }
        public Nullable<int> CurrentTerm { get; set; }
        public Nullable<int> CurrentYear { get; set; }
        public Nullable<decimal> TotalAmount { get; set; }
        public Nullable<System.DateTime> Last_Modified_Date { get; set; }
        public string Last_Modified_Authid { get; set; }
        public string Last_Modified_Uid { get; set; }
        public string Status { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
    }
}