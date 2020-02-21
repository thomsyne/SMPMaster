using SMP.app.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace SMP.Controllers.Admin
{
    public class SchoolfeePaymentController : Controller
    {
        // GET: SchoolfeePayment
        public ActionResult Index(int id = 0, int taskid = 7)
        {
            try
            {
                IEnumerable<SchoolfeePayment> SchoolfeePaymentList = null;

                HttpResponseMessage resp = GlobalVariables.client.GetAsync("GetSchoolfeePayment?id=" + id + "&taskid=" + taskid).Result;
                if (resp.IsSuccessStatusCode)
                {
                    SchoolfeePaymentList = resp.Content.ReadAsAsync<IEnumerable<SchoolfeePayment>>().Result;
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                }
                return View(SchoolfeePaymentList);
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
                return View(new SchoolfeePayment());
            }
            else
            {
                taskid = 6;
                HttpResponseMessage resp = GlobalVariables.client.GetAsync("GetSchoolfeePayment?id=" + id + "&taskid=" + taskid).Result;
                if (resp.IsSuccessStatusCode)
                {
                    var schoolfeepayment = resp.Content.ReadAsAsync<IEnumerable<SchoolfeePayment>>().Result;
                    var record = schoolfeepayment.FirstOrDefault();
                    return View(record);
                }
                return View();
            }
        }

        [HttpPost]
        public ActionResult AddOrEdit(SchoolfeePayment model)
        {
            BindCombo();
            if (model.itbid == 0)
            {
                model.taskid = 2;
                HttpResponseMessage resp = GlobalVariables.client.PostAsJsonAsync("POSTSchoolfeePayment", model).Result;
                TempData["SuccessMessage"] = "Record Saved Successfully";
            }
            else
            {
                model.taskid = 4;
                HttpResponseMessage resp = GlobalVariables.client.PostAsJsonAsync("POSTSchoolfeePayment", model).Result;
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
            IEnumerable<Class> ClassList = null;
            HttpResponseMessage resp2 = GlobalVariables.client.GetAsync("GetClass?id=" + id + "&taskid=" + taskid).Result;
            ClassList = resp2.Content.ReadAsAsync<IEnumerable<Class>>().Result;
            if (!Equals(ClassList, null))
            {
                var classes = ClassList.ToList();
                ViewBag.ClassList = new SelectList(classes, "ItbId", "Name");
            }

            IEnumerable<Student> StudentList = null;
            HttpResponseMessage resp = GlobalVariables.client.GetAsync("GetStudent?id=" + id + "&taskid=" + taskid).Result;
            StudentList = resp.Content.ReadAsAsync<IEnumerable<Student>>().Result;
            if (!Equals(StudentList, null))
            {
                var student = StudentList.ToList();
                ViewBag.StudentList = new SelectList(student, "ItbId", "Student_Code");
            }

            IEnumerable<Arms> ArmsList = null;
            HttpResponseMessage resp1 = GlobalVariables.client.GetAsync("GetArms?id=" + id + "&taskid=" + taskid).Result;
            ArmsList = resp1.Content.ReadAsAsync<IEnumerable<Arms>>().Result;
            if (!Equals(ArmsList, null))
            {
                var arms = ArmsList.ToList();
                ViewBag.ArmsList = new SelectList(arms, "ItbId", "Name");
            }

            IEnumerable<StudentType> StudentTypeList = null;
            HttpResponseMessage resp4 = GlobalVariables.client.GetAsync("GetStudentType?id=" + id + "&taskid=" + taskid).Result;
            StudentTypeList = resp4.Content.ReadAsAsync<IEnumerable<StudentType>>().Result;
            if (!Equals(StudentTypeList, null))
            {
                var studenttype = StudentTypeList.ToList();
                ViewBag.StudentTypeList = new SelectList(studenttype, "ItbId", "Student_Type");
            }
        }
    }
}