using SMP.app.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace SMP.Controllers.Admin
{
    public class ArmsController : Controller
    {
        // GET: Arms
        public ActionResult Index(int id = 0, int taskid = 7)
        {
            try
            {
                IEnumerable<Arms> ArmsList = null;

                HttpResponseMessage resp = GlobalVariables.client.GetAsync("GetArms?id=" + id + "&taskid=" + taskid).Result;
                if (resp.IsSuccessStatusCode)
                {
                    ArmsList = resp.Content.ReadAsAsync<IEnumerable<Arms>>().Result;
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                }
                return View(ArmsList);
            }
            catch (Exception ex)
            {

                return View(ex.Message);
            }
        }

        public ActionResult AddOrEdit(int id = 0, int taskid = 0)
        {
            BindCombo();
            //Arm model = new Arm();
            if (id == 0)
            {
                return View(new Arms());
            }
            else
            {
                taskid = 6;
                HttpResponseMessage resp = GlobalVariables.client.GetAsync("GetArms?id=" + id + "&taskid=" + taskid).Result;
                if (resp.IsSuccessStatusCode)
                {
                    var arms = resp.Content.ReadAsAsync<IEnumerable<Arms>>().Result;
                    var record = arms.FirstOrDefault();
                    return View(record);
                }
                return View();
            }
        }

        [HttpPost]
        public ActionResult AddOrEdit(Arms model)
        {
            BindCombo();
            if (model.ItbId == 0)
            {
                model.taskid = 2;
                HttpResponseMessage resp = GlobalVariables.client.PostAsJsonAsync("POSTArms", model).Result;
                TempData["SuccessMessage"] = "Record Saved Successfully";
            }
            else
            {
                model.taskid = 4;
                HttpResponseMessage resp = GlobalVariables.client.PostAsJsonAsync("POSTArms", model).Result;
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

            IEnumerable<Class> ClassList = null;
            HttpResponseMessage resp2 = GlobalVariables.client.GetAsync("GetClass?id=" + id + "&taskid=" + taskid).Result;
            ClassList = resp2.Content.ReadAsAsync<IEnumerable<Class>>().Result;
            if (!Equals(ClassList, null))
            {
                var classes = ClassList.ToList();
                ViewBag.ClassList = new SelectList(classes, "ItbId", "Name");
            }

            IEnumerable<Staff_Type> Staff_TypeList = null;
            HttpResponseMessage resp3 = GlobalVariables.client.GetAsync("GetStaff_Type?id=" + id + "&taskid=" + taskid).Result;
            Staff_TypeList = resp3.Content.ReadAsAsync<IEnumerable<Staff_Type>>().Result;
            if (!Equals(Staff_TypeList, null))
            {
                var staffs = Staff_TypeList.ToList();
                ViewBag.Staff_TypeList = new SelectList(staffs, "ItbId", "Name");
            }

            IEnumerable<Campus> CampusList = null;
            HttpResponseMessage resp4 = GlobalVariables.client.GetAsync("GetCampus?id=" + id + "&taskid=" + taskid).Result;
            CampusList = resp4.Content.ReadAsAsync<IEnumerable<Campus>>().Result;
            if (!Equals(CampusList, null))
            {
                var campuses = CampusList.ToList();
                ViewBag.CampusList = new SelectList(campuses, "ItbId", "Name");
            }

            IEnumerable<Staff> StaffList = null;
            HttpResponseMessage resp5 = GlobalVariables.client.GetAsync("GetStaff?id=" + id + "&taskid=" + taskid).Result;
            StaffList = resp5.Content.ReadAsAsync<IEnumerable<Staff>>().Result;
            if (!Equals(StaffList, null))
            {
                var staff = StaffList.ToList();
                ViewBag.StaffList = new SelectList(staff, "ItbId", "LastName");
            }

            IEnumerable<School_Details> School_DetailsList = null;
            HttpResponseMessage resp6 = GlobalVariables.client.GetAsync("GetSchool_Details?id=" + id + "&taskid=" + taskid).Result;
            School_DetailsList = resp6.Content.ReadAsAsync<IEnumerable<School_Details>>().Result;
            if (!Equals(School_DetailsList, null))
            {
                var sch = School_DetailsList.ToList();
                ViewBag.School_DetailsList = new SelectList(sch, "ItbId", "Name");
            }

        }
    }
}