using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SMP.app.Models
{
    public class Student
    {
        public int ItbId { get; set; }
        public int taskid { get; set; }

        [Display(Name = "School")]
        public Nullable<int> SchoolId { get; set; }

        [Display(Name = "Student Code")]
        public string Student_Code { get; set; }

        [Display(Name = "Parent")]
        public Nullable<int> ParentId { get; set; }

        [Display(Name = "Campus")]
        public Nullable<int> CampusId { get; set; }

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
        public byte[] Passport { get; set; }

        [Display(Name = "Arm")]
        public Nullable<int> ArmId { get; set; }
        [Display (Name = "Student Type")]
        public Nullable<int> Student_TypeId { get; set; }

        [Display(Name = "Class")]
        public Nullable<int> ClassId { get; set; }

        [Display(Name = "Prefect")]
        public int PrefectId { get; set; }

        [Display(Name = "Prefect Type")]
        public int Prefect_TypeId { get; set; }

        [Display(Name = "Reigion")]
        public Nullable<int> ReligionId { get; set; }

        [Display(Name = "Date of Birth")]
        public Nullable<System.DateTime> Date_Of_Brith { get; set; }

        [Display(Name = "Admission Date")]
        public Nullable<System.DateTime> Date_Of_Admission { get; set; }

        [Display(Name = "Gender")]
        public Nullable<int> GenderId { get; set; }

        [Display(Name = "Phone No.")]
        public string Phone_No { get; set; }

        [Display(Name = "Program")]
        public Nullable<int> ProgramId { get; set; }

        [Display(Name = "Session")]
        public Nullable<int> SessionId { get; set; }

        [Display(Name = "Parent/Guardian")]
        public string Is_Parent_Or_Guaidian { get; set; }

        [Display(Name = "Blood Group")]
        public Nullable<int> Blood_GroupId { get; set; }
        public Nullable<System.DateTime> Last_Modified_Date { get; set; }
        public string Last_Modified_Authid { get; set; }
        public string Last_Modified_Uid { get; set; }
        public string Status { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
    }
}