using SMP.app.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace SMP.Controllers
{
    public class RouteController : Controller
    {
        void BindCombo()
        {
            int id = 0; int taskid = 7;
            IEnumerable<Campus> CampusList = null;
            HttpResponseMessage resp = GlobalVariables.client.GetAsync("GetCampus?id=" + id + "&taskid=" + taskid).Result;
            CampusList = resp.Content.ReadAsAsync<IEnumerable<Campus>>().Result;
            if (!Equals(CampusList, null))
            {
                var day = CampusList.ToList();
                ViewBag.CampusList = new SelectList(day, "ItbId", "Name");
            }

        }


        IEnumerable<Route> RouteList = null;
        // GET: Schedule
        public ActionResult Index(int id = 0, int taskid = 7)
        {
            try
            {

                HttpResponseMessage resp = GlobalVariables.client.GetAsync("GetRoute?id=" + id + "&taskid=" + taskid).Result;
                if (resp.IsSuccessStatusCode)
                {
                    RouteList = resp.Content.ReadAsAsync<IEnumerable<Route>>().Result;
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                }
                return View(RouteList);
            }
            catch (Exception ex)
            {

                return View(ex.Message);
            }
        }

        public ActionResult AddOrEdit(int id = 0, int taskid = 0)
        {
            BindCombo();
            //ScheduleTimetable model = new ScheduleTimetable();
            if (id == 0)
            {
                return View(new Route());
            }
            else
            {
                taskid = 6;
                HttpResponseMessage resp = GlobalVariables.client.GetAsync("GetRoute?id=" + id + "&taskid=" + taskid).Result;
                if (resp.IsSuccessStatusCode)
                {
                    var Route = resp.Content.ReadAsAsync<IEnumerable<Route>>().Result;
                    var record = Route.FirstOrDefault();
                    return View(record);
                }
                return View();
            }
        }

        [HttpPost]
        public ActionResult AddOrEdit(Route model)
        {
            BindCombo();

            if (model.ItbId == 0)
            {
                model.taskid = 2;
                HttpResponseMessage resp = GlobalVariables.client.PostAsJsonAsync("POSTRoute", model).Result;
                TempData["SuccessMessage"] = "Record Saved Successfully";
            }
            else
            {
                model.taskid = 4;
                HttpResponseMessage resp = GlobalVariables.client.PostAsJsonAsync("POSTRoute", model).Result;
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