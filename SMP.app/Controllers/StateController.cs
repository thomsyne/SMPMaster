using SMP.app;
using SMP.app.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace SMP.Controllers.Admin
{
    public class StateController : Controller
    {
        // GET: State
        public ActionResult Index(int id = 0, int taskid = 7)
        {
            try
            {
                IEnumerable<State> StateList = null;

                HttpResponseMessage resp = GlobalVariables.client.GetAsync("GetState?id=" + id + "&taskid=" + taskid).Result;
                if (resp.IsSuccessStatusCode)
                {
                    StateList = resp.Content.ReadAsAsync<IEnumerable<State>>().Result;
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                }
                return View(StateList);
            }
            catch (Exception ex)
            {

                return View(ex.Message);
            }
        }

        public ActionResult AddOrEdit(int id = 0, int taskid = 0)
        {
            BindCombo();
            //State model = new State();
            if (id == 0)
            {
                return View(new State());
            }
            else
            {
                taskid = 6;
                HttpResponseMessage resp = GlobalVariables.client.GetAsync("GetState?id=" + id + "&taskid=" + taskid).Result;
                if (resp.IsSuccessStatusCode)
                {
                    var states = resp.Content.ReadAsAsync<IEnumerable<State>>().Result;
                    var record = states.FirstOrDefault();
                    return View(record);
                }
                return View();
            }
        }

        [HttpPost]
        public ActionResult AddOrEdit(State model)
        {
            BindCombo();
            if (model.ItbId == 0)
            {
                model.taskid = 2;
                HttpResponseMessage resp = GlobalVariables.client.PostAsJsonAsync("POSTState", model).Result;
                TempData["SuccessMessage"] = "Record Saved Successfully";
            }
            else
            {
                model.taskid = 4;
                HttpResponseMessage resp = GlobalVariables.client.PostAsJsonAsync("POSTState", model).Result;
                TempData["SuccessMessage"] = "Record Updated Successfully";
            }
            return RedirectToAction("Index");
        }

        void BindCombo()
        {
            int id = 0; int taskid = 7;
            IEnumerable<Country> CountryList = null;
            HttpResponseMessage resp1 = GlobalVariables.client.GetAsync("GetCountry?id=" + id + "&taskid=" + taskid).Result;
            CountryList = resp1.Content.ReadAsAsync<IEnumerable<Country>>().Result;
            if (!Equals(CountryList, null))
            {
                var coun = CountryList.ToList();
                ViewBag.CountryList = new SelectList(coun, "ItbId", "Country_Name");
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