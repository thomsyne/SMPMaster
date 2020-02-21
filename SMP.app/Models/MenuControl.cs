using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SMP.app.Models
{
    public class MenuControl
    {
        public int MenuId { get; set; }
        public int taskid { get; set; }
        [Display(Name = "Menu ")]
        public string MenuName { get; set; }
        [Display(Name = "Url")]
        public string Url { get; set; }
        [Display(Name = "Parent")]
        public Nullable<int> Parent { get; set; }
        [Display(Name = "Priority")]
        public Nullable<int> Priority { get; set; }
        public string Status { get; set; }
        public Nullable<bool> Flag { get; set; }
        public string AppType { get; set; }
        public string ResourceKey { get; set; }
        public string HasNode { get; set; }

        public byte[] CreatedBy { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
    }
}