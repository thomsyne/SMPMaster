using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SMP.app.Models
{
    public class Staff_RefereeData
    {
        public int ItbId { get; set; }
        public int taskid { get; set; }

        [Display(Name = "Staff")]
        public Nullable<int> StaffId { get; set; }
        [Display(Name = "Title")]
        public string Title { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Middle Name")]
        public string MiddleName { get; set; }

        [Display(Name = "Address")]
        public string ContactAddress { get; set; }

        [Display(Name = "Country")]
        public Nullable<int> CountryId { get; set; }

        [Display(Name = "State")]
        public Nullable<int> StateId { get; set; }

        [Display(Name = "City")]
        public string City { get; set; }

        [Display(Name = "Email")]
        public string Email { get; set; }

        [Display(Name = "Phone No")]
        public string MobilePhone { get; set; }

        [Display(Name = "Home Phone")]
        public string HomePhone { get; set; }

        [Display(Name = "Work Phone")]
        public string WorkPhone { get; set; }

        [Display(Name = "Relationship")]
        public string Relationship { get; set; }

        [Display(Name = "Company")]
        public string Company { get; set; }

        [Display(Name = "Position")]
        public string Position { get; set; }

        public Nullable<System.DateTime> Last_Modified_Date { get; set; }
        public string Last_Modified_Authid { get; set; }
        public string Last_Modified_Uid { get; set; }
        public string Status { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
    }
}