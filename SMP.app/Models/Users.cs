using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SMP.app.Models
{
    public class Users
    {
        public int ItbId { get; set; }
        public int taskid { get; set; }

        [Display(Name = "Name")]
        public string Name { get; set; }
        
        [Display(Name ="Username")]
        public string Username { get; set; }

        [Display(Name ="Email")]
        public string Email { get; set; }

        [Display(Name = "Phone #")]
        public string Phone_No { get; set; }

        [Display(Name = "Address")]
        public string Address { get; set; }

        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Account Type")]
        public Nullable<int> Account_TypeId { get; set; }
        public byte[] Photo { get; set; }
        public Nullable<System.DateTime> Last_Modified_Date { get; set; }
        public string Last_Modified_Authid { get; set; }
        public string Last_Modified_Uid { get; set; }
        public string Status { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
    }
}