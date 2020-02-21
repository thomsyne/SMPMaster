using SMP.app.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace SMP.Controllers.School_Management
{
    public class SchoolBusController : Controller
    {
        // GET: SchoolBus
        public ActionResult Index(int id = 0, int taskid = 7)
        {
            try
            {
                IEnumerable<School_Bus> SchoolBusList = null;

                HttpResponseMessage resp = GlobalVariables.client.GetAsync("GetSchool_Bus?id=" + id + "&taskid=" + taskid).Result;
                if (resp.IsSuccessStatusCode)
                {
                    SchoolBusList = resp.Content.ReadAsAsync<IEnumerable<School_Bus>>().Result;
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                }
                return View(SchoolBusList);
            }
            catch (Exception ex)
            {

                return View(ex.Message);
            }
        }

        public ActionResult AddOrEdit(int id = 0, int taskid = 0)
        {
            BindCombo();
            //Student model = new Student();
            if (id == 0)
            {
                return View(new School_Bus());
            }
            else
            {
                taskid = 6;
                HttpResponseMessage resp = GlobalVariables.client.GetAsync("GetSchool_Bus?id=" + id + "&taskid=" + taskid).Result;
                if (resp.IsSuccessStatusCode)
                {
                    var SchoolBus = resp.Content.ReadAsAsync<IEnumerable<School_Bus>>().Result;
                    var record = SchoolBus.FirstOrDefault();
                    return View(record);
                }
                return View();
            }
            //return View();
        }

        [HttpPost]
        public ActionResult AddOrEdit(School_Bus model)
        {
            BindCombo();
            if (model.ItbId == 0)
            {
                model.taskid = 2;
                HttpResponseMessage resp = GlobalVariables.client.PostAsJsonAsync("POSTSchool_Bus", model).Result;
                TempData["SuccessMessage"] = "Record Saved Successfully";
            }
            else
            {
                model.taskid = 4;
                HttpResponseMessage resp = GlobalVariables.client.PostAsJsonAsync("POSTSchool_Bus", model).Result;
                TempData["SuccessMessage"] = "Record Updated Successfully";
            }
            return RedirectToAction("Index");
        }
        void BindCombo()
        {
            int id = 0; int taskid = 7;
            IEnumerable<Route> RouteList = null;
            HttpResponseMessage resp1 = GlobalVariables.client.GetAsync("GetRoute?id=" + id + "&taskid=" + taskid).Result;
            RouteList = resp1.Content.ReadAsAsync<IEnumerable<Route>>().Result;
            if (!Equals(RouteList, null))
            {
                var programs = RouteList.ToList();
                ViewBag.RouteList = new SelectList(programs, "ItbId", "RouteName");
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

            //public ActionResult Delete(int id)
            //{
            //    HttpResponseMessage resp = GlobalVariables.client.DeleteAsync("http://localhost/schoolwebapi/" + id.ToString()).Result;
            //    TempData["SuccessMessage"] = "Record Deleted Successfully";
            //    return RedirectToAction("Index");
            //}
        }
}