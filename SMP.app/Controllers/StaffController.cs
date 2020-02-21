using SMP.app.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace SMP.Controllers
{
    public class StaffController : Controller
    {
        // GET: Staff
        public ActionResult Index(int id = 0, int taskid = 7)
        {
            try
            {
                IEnumerable<Staff> StaffList = null;

                HttpResponseMessage resp = GlobalVariables.client.GetAsync("GetStaff?id=" + id + "&taskid=" + taskid).Result;
                if (resp.IsSuccessStatusCode)
                {
                    StaffList = resp.Content.ReadAsAsync<IEnumerable<Staff>>().Result;
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                }
                return View(StaffList);
            }
            catch (Exception ex)
            {

                return View(ex.Message);
            }
        }

        public ActionResult AddOrEdit(int id = 0, int taskid = 0)
        {
            BindCombo();
            if (id == 0)
            {
                return View(new Staff());
            }
            else
            {
                taskid = 6;
                HttpResponseMessage resp = GlobalVariables.client.GetAsync("GetStaff?id=" + id + "&taskid=" + taskid).Result;
                if (resp.IsSuccessStatusCode)
                {
                    var staffs = resp.Content.ReadAsAsync<IEnumerable<Staff>>().Result;
                    var record = staffs.FirstOrDefault();
                    return View(record);
                }
                return View();
            }
        }

        [HttpPost]
        public ActionResult AddOrEdit(Staff model)
        {
            BindCombo();
            if (model.ItbId == 0)
            {
                model.taskid = 2;
                HttpResponseMessage resp = GlobalVariables.client.PostAsJsonAsync("POSTStaff", model).Result;
                TempData["SuccessMessage"] = "Record Saved Successfully";
            }
            else
            {
                model.taskid = 4;
                HttpResponseMessage resp = GlobalVariables.client.PostAsJsonAsync("POSTStaff", model).Result;
                TempData["SuccessMessage"] = "Record Updated Successfully";
            }
            return RedirectToAction("Index");
        }

        //public ActionResult Delete(int id)
        //{
        //    HttpResponseMessage resp = GlobalVariables.client.DeleteAsync("http://localhost/schoolwebapi/" + id.ToString()).Result;
        //    TempData["SuccessMessage"] = "Record Deleted Successfully";
        //    return RedirectToAction("Index");
        //}

        void BindCombo()
        {
            int id = 0; int taskid = 7;
            IEnumerable<Program> ProgramList = null;
            HttpResponseMessage resp1 = GlobalVariables.client.GetAsync("GetProgram?id=" + id + "&taskid=" + taskid).Result;
            ProgramList = resp1.Content.ReadAsAsync<IEnumerable<Program>>().Result;
            if (!Equals(ProgramList, null))
            {
                var programs = ProgramList.ToList();
                ViewBag.ProgramList = new SelectList(programs, "ItbId", "Program_Name");
            }

            IEnumerable<School_Details> School_DetailsList = null;
            HttpResponseMessage resp2 = GlobalVariables.client.GetAsync("GetSchool_Details?id=" + id + "&taskid=" + taskid).Result;
            School_DetailsList = resp2.Content.ReadAsAsync<IEnumerable<School_Details>>().Result;
            if (!Equals(School_DetailsList, null))
            {
                var school = School_DetailsList.ToList();
                ViewBag.School_DetailsList = new SelectList(school, "ItbId", "Name");
            }

            IEnumerable<Country> CountryList = null;
            HttpResponseMessage resp3 = GlobalVariables.client.GetAsync("GetCountry?id=" + id + "&taskid=" + taskid).Result;
            CountryList = resp3.Content.ReadAsAsync<IEnumerable<Country>>().Result;
            if (!Equals(CountryList, null))
            {
                var country = CountryList.ToList();
                ViewBag.CountryList = new SelectList(country, "ItbId", "Country_Name");
            }

            IEnumerable<State> StateList = null;
            HttpResponseMessage resp4 = GlobalVariables.client.GetAsync("GetState?id=" + id + "&taskid=" + taskid).Result;
            StateList = resp4.Content.ReadAsAsync<IEnumerable<State>>().Result;
            if (!Equals(StateList, null))
            {
                var state = StateList.ToList();
                ViewBag.StateList = new SelectList(state, "ItbId", "State_Name");
            }

            IEnumerable<Blood_Group> Blood_GroupList = null;
            HttpResponseMessage resp5 = GlobalVariables.client.GetAsync("GetBlood_Group?id=" + id + "&taskid=" + taskid).Result;
            Blood_GroupList = resp5.Content.ReadAsAsync<IEnumerable<Blood_Group>>().Result;
            if (!Equals(Blood_GroupList, null))
            {
                var blood_group = Blood_GroupList.ToList();
                ViewBag.Blood_GroupList = new SelectList(blood_group, "ItbId", "Name");
            }

            IEnumerable<Gender> GenderList = null;
            HttpResponseMessage resp6 = GlobalVariables.client.GetAsync("GetGender?id=" + id + "&taskid=" + taskid).Result;
            GenderList = resp6.Content.ReadAsAsync<IEnumerable<Gender>>().Result;
            if (!Equals(GenderList, null))
            {
                var gender = GenderList.ToList();
                ViewBag.GenderList = new SelectList(gender, "ItbId", "Gender_Name");
            }

            IEnumerable<Marital_Status> Marital_StatusList = null;
            HttpResponseMessage resp7 = GlobalVariables.client.GetAsync("GetMarital_Status?id=" + id + "&taskid=" + taskid).Result;
            Marital_StatusList = resp7.Content.ReadAsAsync<IEnumerable<Marital_Status>>().Result;
            if (!Equals(Marital_StatusList, null))
            {
                var marital_status = Marital_StatusList.ToList();
                ViewBag.Marital_StatusList = new SelectList(marital_status, "ItbId", "Name");
            }

            IEnumerable<Designation> DesignationList = null;
            HttpResponseMessage resp8 = GlobalVariables.client.GetAsync("GetDesignation?id=" + id + "&taskid=" + taskid).Result;
            DesignationList = resp8.Content.ReadAsAsync<IEnumerable<Designation>>().Result;
            if (!Equals(DesignationList, null))
            {
                var designation = DesignationList.ToList();
                ViewBag.DesignationList = new SelectList(designation, "ItbId", "Name");
            }

            IEnumerable<Staff_Type> Staff_TypeList = null;
            HttpResponseMessage resp9 = GlobalVariables.client.GetAsync("GetStaff_Type?id=" + id + "&taskid=" + taskid).Result;
            Staff_TypeList = resp9.Content.ReadAsAsync<IEnumerable<Staff_Type>>().Result;
            if (!Equals(Staff_TypeList, null))
            {
                var staff_type = Staff_TypeList.ToList();
                ViewBag.Staff_TypeList = new SelectList(staff_type, "ItbId", "Name");
            }

            IEnumerable<Department> DepartmentList = null;
            HttpResponseMessage resp10 = GlobalVariables.client.GetAsync("GetDepartment?id=" + id + "&taskid=" + taskid).Result;
            DepartmentList = resp10.Content.ReadAsAsync<IEnumerable<Department>>().Result;
            if (!Equals(DepartmentList, null))
            {
                var department = DepartmentList.ToList();
                ViewBag.DepartmentList = new SelectList(department, "ItbId", "Dept_Name");
            }

            IEnumerable<Subject> SubjectList = null;
            HttpResponseMessage resp11 = GlobalVariables.client.GetAsync("GetSubject?id=" + id + "&taskid=" + taskid).Result;
            SubjectList = resp11.Content.ReadAsAsync<IEnumerable<Subject>>().Result;
            if (!Equals(SubjectList, null))
            {
                var subject = SubjectList.ToList();
                ViewBag.SubjectList = new SelectList(subject, "ItbId", "Subject_Name");
            }

            IEnumerable<Campus> CampusList = null;
            HttpResponseMessage resp12 = GlobalVariables.client.GetAsync("GetCampus?id=" + id + "&taskid=" + taskid).Result;
            CampusList = resp12.Content.ReadAsAsync<IEnumerable<Campus>>().Result;
            if (!Equals(CampusList, null))
            {
                var camp = CampusList.ToList();
                ViewBag.CampusList = new SelectList(camp, "ItbId", "Name");
            }

            IEnumerable<LevelSetup> LevelSetupList = null;
            HttpResponseMessage resp15 = GlobalVariables.client.GetAsync("GetLevelSetup?id=" + id + "&taskid=" + taskid).Result;
            LevelSetupList = resp15.Content.ReadAsAsync<IEnumerable<LevelSetup>>().Result;
            if (!Equals(LevelSetupList, null))
            {
                var lset = LevelSetupList.ToList();
                ViewBag.LevelSetupList = new SelectList(lset, "ItbId", "HR_Level");
            }

            IEnumerable<LeaveType> LeaveTypeList = null;
            HttpResponseMessage resp16 = GlobalVariables.client.GetAsync("GetLeaveType?id=" + id + "&taskid=" + taskid).Result;
            LeaveTypeList = resp16.Content.ReadAsAsync<IEnumerable<LeaveType>>().Result;
            if (!Equals(LeaveTypeList, null))
            {
                var lt = LeaveTypeList.ToList();
                ViewBag.LeaveTypeList = new SelectList(lt, "ItbId", "Description");
            }
        }
    }
}