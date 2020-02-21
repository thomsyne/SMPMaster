using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SMP.app.Models
{
    public class Events
    {
        public int ItbId { get; set; }
        public int taskid { get; set; }
        [Display(Name="Event Title")]
        public string Event_Title { get; set; }

        [Display(Name = "Venue")]
        public string Venue { get; set; }

        [Display(Name = "Description")]
        public string Description { get; set; }
        [Display(Name = "Start Date")]
        public Nullable<System.DateTime> StartDate { get; set; }
        [Display(Name = "Start Time")]
        public Nullable<System.TimeSpan> StartTime { get; set; }
        [Display(Name = "End Date")]
        public Nullable<System.DateTime> EndDate { get; set; }
        [Display(Name = "End Time")]
        public Nullable<System.TimeSpan> EndTime { get; set; }
        [Display(Name = "Event Type")]
        public string Event_Type { get; set; }
        [Display(Name = "Event Fee")]
        public string Event_Fee { get; set; }
        [Display(Name = "Session")]
        public Nullable<int> SessionId { get; set; }

        [Display(Name = "Campus")]
        public Nullable<int> CampusId { get; set; }

        [Display(Name = "Term")]
        public Nullable<int> TermId { get; set; }
        [Display(Name = "School")]
        public Nullable<int> SchoolId { get; set; }
        public Nullable<System.DateTime> Last_Modified_Date { get; set; }
        public string Last_Modified_Authid { get; set; }
        public string Last_Modified_Uid { get; set; }
        public string Status { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
    }
}