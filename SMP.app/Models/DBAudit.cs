using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SMP.app.Models
{
    public class DBAudit
    {
        public int ItbId { get; set; }
        public int taskid { get; set; }
        [Display(Name = "Audit log")]
        public System.Guid AuditlogId { get; set; }
        [Display(Name = "Event Date")]
        public System.DateTime EventDateutc { get; set; }
        [Display(Name = "Event Type")]
        public string EventType { get; set; }
        [Display(Name = "Table Name")]
        public string TableName { get; set; }
        [Display(Name = "Record")]
        public Nullable<int> RecordId { get; set; }
        [Display(Name = "Column Name")]
        public string ColumnName { get; set; }
        [Display(Name = "Original Value")]
        public string OriginalValue { get; set; }
        [Display(Name = "New Value")]
        public string NewValue { get; set; }
        public string Last_Modified_Authid { get; set; }
        public string Last_Modified_Uid { get; set; }
        public string Status { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
    }
}