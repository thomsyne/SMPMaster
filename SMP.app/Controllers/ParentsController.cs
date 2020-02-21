using SMP.app.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace SMP.Controllers.School_Management
{
    public class ParentsController : Controller
    {
        void BindCombo()
        {
            int id = 0; int taskid = 7;
            IEnumerable<Country> CountryList = null;
            HttpResponseMessage resp = GlobalVariables.client.GetAsync("GetCountry?id=" + id + "&taskid=" + taskid).Result;
            CountryList = resp.Content.ReadAsAsync<IEnumerable<Country>>().Result;
            if (!Equals(CountryList, null))
            {
                var Countries = CountryList.ToList();
                ViewBag.CountryList = new SelectList(Countries, "ItbId", "Country_Name");
            }

            IEnumerable<State> StateList = null;
            HttpResponseMessage resp1 = GlobalVariables.client.GetAsync("GetState?id=" + id + "&taskid=" + taskid).Result;
            StateList = resp1.Content.ReadAsAsync<IEnumerable<State>>().Result;
            if (!Equals(StateList, null))
            {
                var States = StateList.ToList();
                ViewBag.StateList = new SelectList(States, "ItbId", "State_Name");
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

        IEnumerable<Parents> ParentsList = null;
        // GET: Parent
        public ActionResult Index(int id = 0, int taskid = 7)
        {
            try
            {
                HttpResponseMessage resp = GlobalVariables.client.GetAsync("GetParents?id=" + id + "&taskid=" + taskid).Result;
                if (resp.IsSuccessStatusCode)
                {
                    ParentsList = resp.Content.ReadAsAsync<IEnumerable<Parents>>().Result;
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                }
                return View(ParentsList);
            }
            catch (Exception ex)
            {

                return View(ex.Message);
            }
        }

        public ActionResult AddOrEdit(int id = 0, int taskid = 0)
        {
            BindCombo();
            //Parent model = new Parent();
            if (id == 0)
            {
                return View(new Parents());
            }
            else
            {
                taskid = 6;
                HttpResponseMessage resp = GlobalVariables.client.GetAsync("GetParents?id=" + id + "&taskid=" + taskid).Result;
                if (resp.IsSuccessStatusCode)
                {
                    var Parents = resp.Content.ReadAsAsync<IEnumerable<Parents>>().Result;
                    var record = Parents.FirstOrDefault();
                    return View(record);
                }
                return View();
            }
            //return View();
        }

        [HttpPost]
        public ActionResult AddOrEdit(Parents model)
        {
            BindCombo();
            if (model.ItbId == 0)
            {
                model.taskid = 2;
                HttpResponseMessage resp = GlobalVariables.client.PostAsJsonAsync("POSTParents", model).Result;
                TempData["SuccessMessage"] = "Record Saved Successfully";
            }
            else
            {
                model.taskid = 4;
                HttpResponseMessage resp = GlobalVariables.client.PostAsJsonAsync("POSTParents", model).Result;
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