using SMP.app.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace SMP.Controllers.Admin
{
    public class Permission_StudentController : Controller
    {
        // GET: Campus
        public ActionResult Index(int id = 0, int taskid = 7)
        {
            try
            {
                IEnumerable<Permission_Student> Permission_StudentList = null;

                HttpResponseMessage resp = GlobalVariables.client.GetAsync("GetPermission_Student?id=" + id + "&taskid=" + taskid).Result;
                if (resp.IsSuccessStatusCode)
                {
                    Permission_StudentList = resp.Content.ReadAsAsync<IEnumerable<Permission_Student>>().Result;
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                }
                return View(Permission_StudentList);
            }
            catch (Exception ex)
            {

                return View(ex.Message);
            }
        }

        public ActionResult AddOrEdit(int id = 0, int taskid = 0)
        {
            BindCombo();
            //Permission_Staff model = new Permission_Staff();
            if (id == 0)
            {
                return View(new Permission_Student());
            }
            else
            {
                taskid = 6;
                HttpResponseMessage resp = GlobalVariables.client.GetAsync("GetPermission_Student?id=" + id + "&taskid=" + taskid).Result;
                if (resp.IsSuccessStatusCode)
                {
                    var Permission_Student = resp.Content.ReadAsAsync<IEnumerable<Permission_Student>>().Result;
                    var record = Permission_Student.FirstOrDefault();
                    return View(record);
                }
                return View();
            }
        }

        [HttpPost]
        public ActionResult AddOrEdit(Permission_Student model)
        {
            BindCombo();
            if (model.ItbId == 0)
            {
                model.taskid = 2;
                HttpResponseMessage resp = GlobalVariables.client.PostAsJsonAsync("POSTPermission_Student", model).Result;
                TempData["SuccessMessage"] = "Record Saved Successfully";
            }
            else
            {
                model.taskid = 4;
                HttpResponseMessage resp = GlobalVariables.client.PostAsJsonAsync("POSTPermission_Student", model).Result;
                TempData["SuccessMessage"] = "Record Updated Successfully";
            }
            return RedirectToAction("Index");
        }

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

            IEnumerable<Arms> ArmsList = null;
            HttpResponseMessage resp2 = GlobalVariables.client.GetAsync("GetArms?id=" + id + "&taskid=" + taskid).Result;
            ArmsList = resp2.Content.ReadAsAsync<IEnumerable<Arms>>().Result;
            if (!Equals(ArmsList, null))
            {
                var arm = ArmsList.ToList();
                ViewBag.ArmsList = new SelectList(arm, "ItbId", "Name");
            }

            IEnumerable<Student> StudentList = null;
            HttpResponseMessage resp3 = GlobalVariables.client.GetAsync("GetStudent?id=" + id + "&taskid=" + taskid).Result;
            StudentList = resp3.Content.ReadAsAsync<IEnumerable<Student>>().Result;
            if (!Equals(StudentList, null))
            {
                var stu = StudentList.ToList();
                ViewBag.StudentList = new SelectList(stu, "ItbId", "Student_Code");
            }

            IEnumerable<Session> SessionList = null;
            HttpResponseMessage resp4 = GlobalVariables.client.GetAsync("GetSession?id=" + id + "&taskid=" + taskid).Result;
            SessionList = resp4.Content.ReadAsAsync<IEnumerable<Session>>().Result;
            if (!Equals(SessionList, null))
            {
                var ses = SessionList.ToList();
                ViewBag.SessionList = new SelectList(ses, "ItbId", "Name");
            }

            IEnumerable<Term> TermList = null;
            HttpResponseMessage resp5 = GlobalVariables.client.GetAsync("GetTerm?id=" + id + "&taskid=" + taskid).Result;
            TermList = resp5.Content.ReadAsAsync<IEnumerable<Term>>().Result;
            if (!Equals(TermList, null))
            {
                var term = TermList.ToList();
                ViewBag.TermList = new SelectList(term, "ItbId", "Term_Name");
            }

            IEnumerable<School_Details> School_DetailsList = null;
            HttpResponseMessage resp6 = GlobalVariables.client.GetAsync("GetSchool_Details?id=" + id + "&taskid=" + taskid).Result;
            School_DetailsList = resp6.Content.ReadAsAsync<IEnumerable<School_Details>>().Result;
            if (!Equals(School_DetailsList, null))
            {
                var sch = School_DetailsList.ToList();
                ViewBag.School_DetailsList = new SelectList(sch, "ItbId", "Name");
            }

            IEnumerable<Class> ClassList = null;
            HttpResponseMessage resp7 = GlobalVariables.client.GetAsync("GetClass?id=" + id + "&taskid=" + taskid).Result;
            ClassList = resp7.Content.ReadAsAsync<IEnumerable<Class>>().Result;
            if (!Equals(ClassList, null))
            {
                var cl = ClassList.ToList();
                ViewBag.ClassList = new SelectList(cl, "ItbId", "Name");
            }

        }

        //public ActionResult Delete(int id)
        //{
        //    HttpResponseMessage resp = GlobalVariables.client.DeleteAsync("http://localhost/schoolwebapi/" + id.ToString()).Result;
        //    TempData["SuccessMessage"] = "Record Deleted Successfully";
        //    return RedirectToAction("Index");
        //}

    }
}