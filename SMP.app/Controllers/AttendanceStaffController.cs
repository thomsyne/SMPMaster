using SMP.app.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace SMP.Controllers
{
    public class AttendanceStaffController : Controller
    {

        void BindCombo()
        {
            int id = 0; int taskid = 7;
            IEnumerable<Register_Status> Register_StatusList = null;
            HttpResponseMessage resp = GlobalVariables.client.GetAsync("GetRegister_Status?id=" + id + "&taskid=" + taskid).Result;
            Register_StatusList = resp.Content.ReadAsAsync<IEnumerable<Register_Status>>().Result;
            if (!Equals(Register_StatusList, null))
            {
                var Register_Status = Register_StatusList.ToList();
                ViewBag.Register_StatusList = new SelectList(Register_Status, "ItbId", "Name");
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


        IEnumerable<Attendance_Staff> AttendanceStaffList = null;
        // GET: AttendanceStaff
        public ActionResult Index(int id = 0, int taskid = 7)
        {
            try
            {

                HttpResponseMessage resp = GlobalVariables.client.GetAsync("GetAttendance_Staff?id=" + id + "&taskid=" + taskid).Result;
                if (resp.IsSuccessStatusCode)
                {
                    AttendanceStaffList = resp.Content.ReadAsAsync<IEnumerable<Attendance_Staff>>().Result;
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                }
                return View(AttendanceStaffList);
            }
            catch (Exception ex)
            {

                return View(ex.Message);
            }
        }

        public ActionResult AddOrEdit(int id = 0, int taskid = 0)
        {
            BindCombo();
            //Attendance_Staff model = new Attendance_Staff();
            if (id == 0)
            {
                return View(new Attendance_Staff());
            }
            else
            {
                taskid = 6;
                HttpResponseMessage resp = GlobalVariables.client.GetAsync("GetAttendance_Staff?id=" + id + "&taskid=" + taskid).Result;
                if (resp.IsSuccessStatusCode)
                {
                    var AttendanceStaff = resp.Content.ReadAsAsync<IEnumerable<Attendance_Staff>>().Result;
                    var record = AttendanceStaff.FirstOrDefault();
                    return View(record);
                }
                return View();
            }
        }

        [HttpPost]
        public ActionResult AddOrEdit(Attendance_Staff model)
        {
            BindCombo();
            if (model.ItbId == 0)
            {
                model.taskid = 2;
                HttpResponseMessage resp = GlobalVariables.client.PostAsJsonAsync("POSTAttendance_Staff", model).Result;
                TempData["SuccessMessage"] = "Record Saved Successfully";
            }
            else
            {
                model.taskid = 4;
                HttpResponseMessage resp = GlobalVariables.client.PostAsJsonAsync("POSTAttendance_Staff", model).Result;
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
    }
}