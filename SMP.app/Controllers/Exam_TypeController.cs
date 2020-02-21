using SMP.app.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace SMP.Controllers.Admin
{
    public class Exam_TypeController : Controller
    {
        // GET: Exam_Type
        public ActionResult Index(int id = 0, int taskid = 7)
        {
            try
            {
                IEnumerable<Exam_Type> Exam_TypeList = null;

                HttpResponseMessage resp = GlobalVariables.client.GetAsync("GetExam_Type?id=" + id + "&taskid=" + taskid).Result;
                if (resp.IsSuccessStatusCode)
                {
                    Exam_TypeList = resp.Content.ReadAsAsync<IEnumerable<Exam_Type>>().Result;
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                }
                return View(Exam_TypeList);
            }
            catch (Exception ex)
            {

                return View(ex.Message);
            }
        }

        public ActionResult AddOrEdit(int id = 0, int taskid = 0)
        {
            BindCombo();
          
            //Exam_Type model = new Exam_Type();
            if (id == 0)
            {
                return View(new Exam_Type());
            }
            else
            {
                taskid = 6;
                HttpResponseMessage resp = GlobalVariables.client.GetAsync("GetExam_Type?id=" + id + "&taskid=" + taskid).Result;
                if (resp.IsSuccessStatusCode)
                {
                    var exam_types = resp.Content.ReadAsAsync<IEnumerable<Exam_Type>>().Result;
                    var record = exam_types.FirstOrDefault();
                    return View(record);
                }
                return View();
            }
        }

        [HttpPost]
        public ActionResult AddOrEdit(Exam_Type model)
        {
            BindCombo();
           
            if (model.ItbId == 0)
            {
                model.taskid = 2;
                HttpResponseMessage resp = GlobalVariables.client.PostAsJsonAsync("POSTExam_Type", model).Result;
                TempData["SuccessMessage"] = "Record Saved Successfully";
            }
            else
            {
                model.taskid = 4;
                HttpResponseMessage resp = GlobalVariables.client.PostAsJsonAsync("POSTExam_Type", model).Result;
                TempData["SuccessMessage"] = "Record Updated Successfully";
            }
            return RedirectToAction("Index");
        }

        void BindCombo() {
            int id = 0; int taskid = 7;
            IEnumerable<School_Details> School_DetailsList = null;
            HttpResponseMessage resp6 = GlobalVariables.client.GetAsync("GetSchool_Details?id=" + id + "&taskid=" + taskid).Result;
            School_DetailsList = resp6.Content.ReadAsAsync<IEnumerable<School_Details>>().Result;
            if (!Equals(School_DetailsList, null))
            {
                var sch = School_DetailsList.ToList();
                ViewBag.School_DetailsList = new SelectList(sch, "ItbId", "Name");
            }

            IEnumerable<Exam_Type> Exam_TypeList = null;
            HttpResponseMessage resp7 = GlobalVariables.client.GetAsync("GetExam_Type?id=" + id + "&taskid=" + taskid).Result;
            Exam_TypeList = resp7.Content.ReadAsAsync<IEnumerable<Exam_Type>>().Result;
            if (!Equals(Exam_TypeList, null))
            {
                var etype = Exam_TypeList.ToList();
                ViewBag.Exam_TypeList = new SelectList(etype, "ItbId", "Description");
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