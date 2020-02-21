using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SMP.app.Models
{
    public class C_MenuControl
    {
        public int MenuId { get; set; }
        public int taskid { get; set; }
        [Display(Name = "Menu")]
        public string MenuName { get; set; }
        public string Url { get; set; }
        public Nullable<int> Parent { get; set; }
        public Nullable<int> Priority { get; set; }
        public string Status { get; set; }
        public Nullable<bool> Flag { get; set; }
        public string Description { get; set; }
        [Display(Name = "Table Name")]
        public string TableName { get; set; }
        public string ResourceKey { get; set; }
        public string HasNode { get; set; }
        public Nullable<int> NoLevel { get; set; }
    }
}