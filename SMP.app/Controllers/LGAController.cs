using SMP.app.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace SMP.Controllers.Admin
{
    public class LGAController : Controller
    {
        // GET: LGA
        public ActionResult Index(int id = 0, int taskid = 7)
        {
            try
            {
                IEnumerable<LGA> LGAList = null;

                HttpResponseMessage resp = GlobalVariables.client.GetAsync("GetLGA?id=" + id + "&taskid=" + taskid).Result;
                if (resp.IsSuccessStatusCode)
                {
                    LGAList = resp.Content.ReadAsAsync<IEnumerable<LGA>>().Result;
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                }
                return View(LGAList);
            }
            catch (Exception ex)
            {

                return View(ex.Message);
            }
        }

        public ActionResult AddOrEdit(int id = 0, int taskid = 0)
        {
            BindCombo();
            //LGA model = new LGA();
            if (id == 0)
            {
                return View(new LGA());
            }
            else
            {
                taskid = 6;
                HttpResponseMessage resp = GlobalVariables.client.GetAsync("GetLGA?id=" + id + "&taskid=" + taskid).Result;
                if (resp.IsSuccessStatusCode)
                {
                    var lga = resp.Content.ReadAsAsync<IEnumerable<LGA>>().Result;
                    var record = lga.FirstOrDefault();
                    return View(record);
                }
                return View();
            }
        }

        [HttpPost]
        public ActionResult AddOrEdit(LGA model)
        {
            BindCombo();
            if (model.ItbId == 0)
            {
                model.taskid = 2;
                HttpResponseMessage resp = GlobalVariables.client.PostAsJsonAsync("POSTLGA", model).Result;
                TempData["SuccessMessage"] = "Record Saved Successfully";
            }
            else
            {
                model.taskid = 4;
                HttpResponseMessage resp = GlobalVariables.client.PostAsJsonAsync("POSTLGA", model).Result;
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
            IEnumerable<State> StateList = null;
            HttpResponseMessage resp1 = GlobalVariables.client.GetAsync("GetState?id=" + id + "&taskid=" + taskid).Result;
            StateList = resp1.Content.ReadAsAsync<IEnumerable<State>>().Result;
            if (!Equals(StateList, null))
            {
                var state = StateList.ToList();
                ViewBag.StateList = new SelectList(state, "ItbId", "State_Name");
            }

        }
    }
}