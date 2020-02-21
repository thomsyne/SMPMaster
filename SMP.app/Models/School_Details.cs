using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SMP.app.Models
{
    public class School_Details
    {
        public int ItbId { get; set; }
        public int taskid { get; set; }
        [Display(Name = "School Name")]
        public string Name { get; set; }
        [Display(Name = "School logo")]
        public byte[] Logo { get; set; }
        [Display(Name = "Address")]
        public string Address { get; set; }
        [Display(Name = "LGA")]
        public Nullable<int> LGAId { get; set; }
        [Display(Name = "Country")]
        public Nullable<int> CountryId { get; set; }
        [Display(Name = "State")]
        public Nullable<int> StateId { get; set; }
        [Display(Name = "Town")]
        public string Town { get; set; }
        [Display(Name = "Contact Email")]
        public string Contact_Email { get; set; }
        [Display(Name = "Contact Phone")]
        public string Contact_PhoneNo { get; set; }
        [Display(Name = "Alternate Phone")]
        public string Contact_AlternatePhoneNo { get; set; }
        [Display(Name = "Proprietor Name")]
        public string Proprietor_Name { get; set; }
        [Display(Name = "Proprietor Phone No")]
        public string Proprietor_PhoneNo { get; set; }
        public Nullable<System.DateTime> Last_Modified_Date { get; set; }
        public string Last_Modified_Authid { get; set; }
        public string Last_Modified_Uid { get; set; }
        public string Status { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
    }
}