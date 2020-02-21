using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SMP.app.Models
{
    public class Parents
    {
        public int ItbId { get; set; }
        public int taskid { get; set; }
        [Display(Name = "School")]
        public Nullable<int> SchoolId { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Middle Name")]
        public string MiddleName { get; set; }
        [Display(Name = "Home Address")]
        public string Home_Address { get; set; }
        [Display(Name = "Country")]
        public Nullable<int> CountryId { get; set; }
        [Display(Name = "State")]
        public Nullable<int> StateId { get; set; }
        [Display(Name = "Town")]
        public string Town { get; set; }
        [Display(Name = "Occupation")]
        public string Occupation { get; set; }
        [Display(Name = "Passport")]
        public byte[] Passport { get; set; }
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Display(Name = "Mobile Phone")]
        public int Mobile_Phone1 { get; set; }
        [Display(Name = "Alternative No")]
        public int Mobile_Phone2 { get; set; }
        public Nullable<System.DateTime> Last_Modified_Date { get; set; }
        public string Last_Modified_Authid { get; set; }
        public string Last_Modified_Uid { get; set; }
        public string Status { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
    }
}