using SMP.app.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace SMP.Controllers.Admin
{
    public class SchoolfeeClassPaymentItemsController : Controller
    {
        // GET: SchoolfeeClassPaymentItms
        public ActionResult Index(int id = 0, int taskid = 7)
        {
            try
            {
                IEnumerable<SchoolfeeClassPaymentItems> SchoolfeeClassPaymentItemsList = null;

                HttpResponseMessage resp = GlobalVariables.client.GetAsync("GetSchoolfeeClassPaymentItems?id=" + id + "&taskid=" + taskid).Result;
                if (resp.IsSuccessStatusCode)
                {
                    SchoolfeeClassPaymentItemsList = resp.Content.ReadAsAsync<IEnumerable<SchoolfeeClassPaymentItems>>().Result;
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                }
                return View(SchoolfeeClassPaymentItemsList);
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
                return View(new SchoolfeeClassPaymentItems());
            }
            else
            {
                taskid = 6;
                HttpResponseMessage resp = GlobalVariables.client.GetAsync("GetSchoolfeeClassPaymentItms?id=" + id + "&taskid=" + taskid).Result;
                if (resp.IsSuccessStatusCode)
                {
                    var schoolfeeclasspaymentitems = resp.Content.ReadAsAsync<IEnumerable<SchoolfeeClassPaymentItems>>().Result;
                    var record = schoolfeeclasspaymentitems.FirstOrDefault();
                    return View(record);
                }
                return View();
            }
        }

        [HttpPost]
        public ActionResult AddOrEdit(SchoolfeeClassPaymentItems model)
        {
            BindCombo();
            if (model.itbid == 0)
            {
                model.taskid = 2;
                HttpResponseMessage resp = GlobalVariables.client.PostAsJsonAsync("POSTSchoolfeeClassPaymentItems", model).Result;
                TempData["SuccessMessage"] = "Record Saved Successfully";
            }
            else
            {
                model.taskid = 4;
                HttpResponseMessage resp = GlobalVariables.client.PostAsJsonAsync("POSTSchoolfeeClassPaymentItems", model).Result;
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
            HttpResponseMessage resp1 = GlobalVariables.client.GetAsync("GetClass?id=" + id + "&taskid=" + taskid).Result;
            ClassList = resp1.Content.ReadAsAsync<IEnumerable<Class>>().Result;
            if (!Equals(ClassList, null))
            {
                var classes = ClassList.ToList();
                ViewBag.ClassList = new SelectList(classes, "ItbId", "Name");
            }

            IEnumerable<StudentType> StudentTypeList = null;
            HttpResponseMessage resp4 = GlobalVariables.client.GetAsync("GetStudentType?id=" + id + "&taskid=" + taskid).Result;
            StudentTypeList = resp4.Content.ReadAsAsync<IEnumerable<StudentType>>().Result;
            if (!Equals(StudentTypeList, null))
            {
                var Studenttype = StudentTypeList.ToList();
                ViewBag.StudentTypeList = new SelectList(Studenttype, "ItbId", "Student_Type");
            }
        }
    }
}