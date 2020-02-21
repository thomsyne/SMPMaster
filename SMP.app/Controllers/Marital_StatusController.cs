using SMP.app.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace SMP.Controllers
{
    public class Marital_StatusController : Controller
    {


        IEnumerable<Marital_Status> Marital_StatusList = null;
        // GET: Schedule
        public ActionResult Index(int id = 0, int taskid = 7)
        {
            try
            {

                HttpResponseMessage resp = GlobalVariables.client.GetAsync("GetMarital_Status?id=" + id + "&taskid=" + taskid).Result;
                if (resp.IsSuccessStatusCode)
                {
                    Marital_StatusList = resp.Content.ReadAsAsync<IEnumerable<Marital_Status>>().Result;
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                }
                return View(Marital_StatusList);
            }
            catch (Exception ex)
            {

                return View(ex.Message);
            }
        }

        public ActionResult AddOrEdit(int id = 0, int taskid = 0)
        {
            //BindCombo();
            //ScheduleTimetable model = new ScheduleTimetable();
            if (id == 0)
            {
                return View(new Marital_Status());
            }
            else
            {
                taskid = 6;
                HttpResponseMessage resp = GlobalVariables.client.GetAsync("GetMarital_Status?id=" + id + "&taskid=" + taskid).Result;
                if (resp.IsSuccessStatusCode)
                {
                    var Marital_Status = resp.Content.ReadAsAsync<IEnumerable<Marital_Status>>().Result;
                    var record = Marital_Status.FirstOrDefault();
                    return View(record);
                }
                return View();
            }
        }

        [HttpPost]
        public ActionResult AddOrEdit(Marital_Status model)
        {
            //BindCombo();

            if (model.ItbId == 0)
            {
                model.taskid = 2;
                HttpResponseMessage resp = GlobalVariables.client.PostAsJsonAsync("POSTMarital_Status", model).Result;
                TempData["SuccessMessage"] = "Record Saved Successfully";
            }
            else
            {
                model.taskid = 4;
                HttpResponseMessage resp = GlobalVariables.client.PostAsJsonAsync("POSTMarital_Status", model).Result;
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