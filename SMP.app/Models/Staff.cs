using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SMP.app.Models
{
    public class Staff
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
        [Display(Name = "Staff Code")]
        public string Staff_Code { get; set; }
        [Display(Name = "Address")]
        public string Address { get; set; }
        [Display(Name = "Country")]
        public Nullable<int> CountryId { get; set; }
        [Display(Name = "Campus")]
        public Nullable<int> CampusId { get; set; }
        [Display(Name = "State")]
        public Nullable<int> StateId { get; set; }

        [Display(Name = "Date Of Birth")]
        public Nullable<System.DateTime> Date_Of_Birth { get; set; }
        [Display(Name = "Appointment Date")]
        public Nullable<System.DateTime> Date_Of_Appointment { get; set; }
        [Display(Name = "Mobile Phone")]
        public int Mobile_Phone1 { get; set; }
        [Display(Name = "Alternative")]
        public int Mobile_Phone2 { get; set; }
        [Display(Name = "Photo")]
        public byte[] Photo { get; set; }
        [Display(Name = "Gender")]
        public Nullable<int> GenderId { get; set; }
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Display(Name = "Marital Status")]
        public Nullable<int> Marital_StatusId { get; set; }

        [Display(Name = "Designation")]
        public Nullable<int> DesignationId { get; set; }

        [Display(Name = "Allowance")]
        public Nullable<int> AllowanceSetupId { get; set; }

        [Display(Name = "HR Grade")]
        public Nullable<int> HR_GradeId { get; set; }

        [Display(Name = "Level")]
        public Nullable<int> LevelSetupId { get; set; }

        [Display(Name = "Leave Type")]
        public Nullable<int> LeaveTypeId { get; set; }

        [Display(Name = "Account No")]
        public string Account_No { get; set; }

        [Display(Name = "Office Extension")]
        public string Office_Extension { get; set; }
        [Display(Name = "Staff Type")]
        public Nullable<int> Staff_TypeId { get; set; }
        [Display(Name = "Dept")]
        public Nullable<int> DeptId { get; set; }
        [Display(Name ="Program")]
        public Nullable<int> ProgramId { get; set; }
        [Display(Name = "Subject")]
        public Nullable<int> SubjectId { get; set; }
        [Display(Name ="Blood Group")]
        public Nullable<int> Blood_GroupId { get; set; }

        public string ImageUrl { get; set; }

        public Nullable<System.DateTime> Last_Modified_Date { get; set; }
        public string Last_Modified_Authid { get; set; }
        public string Last_Modified_Uid { get; set; }
        public string Status { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
    }
}