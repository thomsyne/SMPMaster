using SMP.app.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace SMP.Controllers
{
    public class PeriodController : Controller
    {
        void BindCombo()
        {
            int id = 0; int taskid = 7;
            IEnumerable<Day_Table> Day_TableList = null;
            HttpResponseMessage resp = GlobalVariables.client.GetAsync("GetDay_Table?id=" + id + "&taskid=" + taskid).Result;
            Day_TableList = resp.Content.ReadAsAsync<IEnumerable<Day_Table>>().Result;
            if (!Equals(Day_TableList, null))
            {
                var day = Day_TableList.ToList();
                ViewBag.Day_TableList = new SelectList(day, "ItbId", "Day");
            }

        }


        IEnumerable<Period> PeriodList = null;
        // GET: Schedule
        public ActionResult Index(int id = 0, int taskid = 7)
        {
            try
            {

                HttpResponseMessage resp = GlobalVariables.client.GetAsync("GetPeriod?id=" + id + "&taskid=" + taskid).Result;
                if (resp.IsSuccessStatusCode)
                {
                    PeriodList = resp.Content.ReadAsAsync<IEnumerable<Period>>().Result;
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                }
                return View(PeriodList);
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
                return View(new Period());
            }
            else
            {
                taskid = 6;
                HttpResponseMessage resp = GlobalVariables.client.GetAsync("GetPeriod?id=" + id + "&taskid=" + taskid).Result;
                if (resp.IsSuccessStatusCode)
                {
                    var Period = resp.Content.ReadAsAsync<IEnumerable<Period>>().Result;
                    var record = Period.FirstOrDefault();
                    return View(record);
                }
                return View();
            }
        }

        [HttpPost]
        public ActionResult AddOrEdit(Period model)
        {
            BindCombo();

            if (model.ItbId == 0)
            {
                model.taskid = 2;
                HttpResponseMessage resp = GlobalVariables.client.PostAsJsonAsync("POSTPeriod", model).Result;
                TempData["SuccessMessage"] = "Record Saved Successfully";
            }
            else
            {
                model.taskid = 4;
                HttpResponseMessage resp = GlobalVariables.client.PostAsJsonAsync("POSTPeriod", model).Result;
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