using SMP.app.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace SMP.Controllers
{
    public class AttendanceStudentController : Controller
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

            IEnumerable<Session> SessionList = null;
            HttpResponseMessage resp2 = GlobalVariables.client.GetAsync("GetSession?id=" + id + "&taskid=" + taskid).Result;
            SessionList = resp2.Content.ReadAsAsync<IEnumerable<Session>>().Result;
            if (!Equals(SessionList, null))
            {
                var Sessions = SessionList.ToList();
                ViewBag.SessionList = new SelectList(Sessions, "ItbId", "Name");
            }

            IEnumerable<Term> TermList = null;
            HttpResponseMessage resp3 = GlobalVariables.client.GetAsync("GetTerm?id=" + id + "&taskid=" + taskid).Result;
            TermList = resp3.Content.ReadAsAsync<IEnumerable<Term>>().Result;
            if (!Equals(TermList, null))
            {
                var Terms = TermList.ToList();
                ViewBag.TermList = new SelectList(Terms, "ItbId", "Term_Name");
            }

            IEnumerable<School_Details> School_DetailsList = null;
            HttpResponseMessage resp6 = GlobalVariables.client.GetAsync("GetSchool_Details?id=" + id + "&taskid=" + taskid).Result;
            School_DetailsList = resp6.Content.ReadAsAsync<IEnumerable<School_Details>>().Result;
            if (!Equals(School_DetailsList, null))
            {
                var sch = School_DetailsList.ToList();
                ViewBag.School_DetailsList = new SelectList(sch, "ItbId", "Name");
            }

            IEnumerable<Student> StudentList = null;
            HttpResponseMessage resp7 = GlobalVariables.client.GetAsync("GetStudent?id=" + id + "&taskid=" + taskid).Result;
            StudentList = resp7.Content.ReadAsAsync<IEnumerable<Student>>().Result;
            if (!Equals(StudentList, null))
            {
                var sch = StudentList.ToList();
                ViewBag.StudentList = new SelectList(sch, "ItbId", "Student_Code");
            }

        }


        IEnumerable<Attendance_Student> SchoolProfileList = null;
        // GET: AttendanceStudent
        public ActionResult Index(int id = 0, int taskid = 7)
        {
            try
            {
                HttpResponseMessage resp = GlobalVariables.client.GetAsync("GetAttendance_Student?id=" + id + "&taskid=" + taskid).Result;
                if (resp.IsSuccessStatusCode)
                {
                    SchoolProfileList = resp.Content.ReadAsAsync<IEnumerable<Attendance_Student>>().Result;
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                }
                return View(SchoolProfileList);
            }
            catch (Exception ex)
            {

                return View(ex.Message);
            }
        }

        public ActionResult AddOrEdit(int id = 0, int taskid = 0)
        {
            BindCombo();
            //User Attendance_Student = new Attendance_Student();
            if (id == 0)
            {
                return View(new Attendance_Student());
            }
            else
            {
                taskid = 6;
                HttpResponseMessage resp = GlobalVariables.client.GetAsync("GetAttendance_Student?id=" + id + "&taskid=" + taskid).Result;
                if (resp.IsSuccessStatusCode)
                {
                    var AttendanceStudent = resp.Content.ReadAsAsync<IEnumerable<Attendance_Student>>().Result;
                    var record = AttendanceStudent.FirstOrDefault();
                    return View(record);
                }
                return View();
            }
        }

        [HttpPost]
        public ActionResult AddOrEdit(Attendance_Student model)
        {
            BindCombo();
            if (model.ItbId == 0)
            {
                model.taskid = 2;
                HttpResponseMessage resp = GlobalVariables.client.PostAsJsonAsync("POSTAttendance_Student", model).Result;
                TempData["SuccessMessage"] = "Record Saved Successfully";
            }
            else
            {
                model.taskid = 4;
                HttpResponseMessage resp = GlobalVariables.client.PostAsJsonAsync("POSTAttendance_Student", model).Result;
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