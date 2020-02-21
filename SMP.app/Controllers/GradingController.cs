using SMP.app.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace SMP.Controllers.Admin
{
    public class GradingController : Controller
    {
        // GET: Grading
        public ActionResult Index(int id = 0, int taskid = 7)
        {
            try
            {
                IEnumerable<Grading> GradingList = null;

                HttpResponseMessage resp = GlobalVariables.client.GetAsync("GetGrading?id=" + id + "&taskid=" + taskid).Result;
                if (resp.IsSuccessStatusCode)
                {
                    GradingList = resp.Content.ReadAsAsync<IEnumerable<Grading>>().Result;
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                }
                return View(GradingList);
            }
            catch (Exception ex)
            {

                return View(ex.Message);
            }
        }

        public ActionResult AddOrEdit(int id = 0, int taskid = 0)
        {
            BindCombo();
            //Grading model = new Grading();
            if (id == 0)
            {
                return View(new Grading());
            }
            else
            {
                taskid = 6;
                HttpResponseMessage resp = GlobalVariables.client.GetAsync("GetGrading?id=" + id + "&taskid=" + taskid).Result;
                if (resp.IsSuccessStatusCode)
                {
                    var gradings = resp.Content.ReadAsAsync<IEnumerable<Grading>>().Result;
                    var record = gradings.FirstOrDefault();
                    return View(record);
                }
                return View();
            }
        }

        [HttpPost]
        public ActionResult AddOrEdit(Grading model)
        {
            BindCombo();
            if (model.ItbId == 0)
            {
                model.taskid = 2;
                HttpResponseMessage resp = GlobalVariables.client.PostAsJsonAsync("POSTGrading", model).Result;
                TempData["SuccessMessage"] = "Record Saved Successfully";
            }
            else
            {
                model.taskid = 4;
                HttpResponseMessage resp = GlobalVariables.client.PostAsJsonAsync("POSTGrading", model).Result;
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
            IEnumerable<Exam_Type> Exam_TypeList = null;
            HttpResponseMessage resp = GlobalVariables.client.GetAsync("GetExam_Type?id=" + id + "&taskid=" + taskid).Result;
            Exam_TypeList = resp.Content.ReadAsAsync<IEnumerable<Exam_Type>>().Result;
            if (!Equals(Exam_TypeList, null))
            {
                var exams = Exam_TypeList.ToList();
                ViewBag.Exam_TypeList = new SelectList(exams, "ItbId", "Description");
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