using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SMP.app.Models
{
    public class C_MigrationHistory
    {
        public string MigrationId { get; set; }
        public int taskid { get; set; }
        public string ContextKey { get; set; }
        public byte[] Model { get; set; }
        public string ProductVersion { get; set; }
    }
}