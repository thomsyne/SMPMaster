using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SMP.app.Models
{   
    public class SchoolPayitemRecord
    {
        public long itbid { get; set; }
        public int SchoolId { get; set; }
        public string SchoolName { get; set; }
        public int CampusId { get; set; }
        public string CampusName { get; set; }
        public string Student_Code { get; set; }
        public int ParentId { get; set; }
        public string ParentName { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string Home_Address { get; set; }
        public int CountryId { get; set; }
        public string CountryName { get; set; }
        public int StateId { get; set; }
        public string StateName { get; set; }
        public string Town { get; set; }
        public byte[] Passport { get; set; }
        public int ArmId { get; set; }
        public string Arm { get; set; }
        public int Student_TypeId { get; set; }
        public string Student_Type { get; set; }
        public int ClassId { get; set; }
        public string ClassName { get; set; }
        public int PrefectId { get; set; }
        public int Prefect_TypeId { get; set; }
        public Nullable<System.DateTime> Date_Of_Brith { get; set; }
        public Nullable<System.DateTime> Date_Of_Admission { get; set; }
        public int GenderId { get; set; }
        public string GenderName { get; set; }
        public int Phone_No { get; set; }
        public int ProgramId { get; set; }
        public string ProgramName { get; set; }
        public int SessionId { get; set; }
        public string SessionName { get; set; }
        public string paycode { get; set; }
        public string payitemdesc { get; set; }
        public string compulsory { get; set; }
        public string Compulsorystate { get; set; }
        public decimal Amountdue { get; set; }
        public int Amountpaid { get; set; }
        public int Lastunpaid { get; set; }
        public Nullable<int> currentyear { get; set; }
        public Nullable<int> currentterm { get; set; }
    }
}
