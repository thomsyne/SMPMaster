using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SMP.app.Models
{
    public class Staff_Academic
    {
        public int ItbId { get; set; }
        public int taskid { get; set; }

        [Display(Name = "Staff")]
        public int StaffId { get; set; }
        [Display(Name = "Institution Name")]
        public string InstitutionName { get; set; }

        [Display(Name = "Qualification Obtained")]
        public string QualificationObtained { get; set; }

        [Display(Name = "Address")]
        public string Address { get; set; }

        [Display(Name = "Graduation Year")]
        public string GraduationYear { get; set; }

        public Nullable<System.DateTime> Last_Modified_Date { get; set; }
        public string Last_Modified_Authid { get; set; }
        public string Last_Modified_Uid { get; set; }
        public string Status { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
    }
}