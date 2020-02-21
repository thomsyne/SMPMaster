using SMP.app.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace SMP.Controllers.Admin
{
    public class DivisionController : Controller
    {
        // GET: Division
        public ActionResult Index(int id = 0, int taskid = 7)
        {
            try
            {
                IEnumerable<Division> DivisionList = null;

                HttpResponseMessage resp = GlobalVariables.client.GetAsync("GetDivision?id=" + id + "&taskid=" + taskid).Result;
                if (resp.IsSuccessStatusCode)
                {
                    DivisionList = resp.Content.ReadAsAsync<IEnumerable<Division>>().Result;
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                }
                return View(DivisionList);
            }
            catch (Exception ex)
            {

                return View(ex.Message);
            }
        }

        public ActionResult AddOrEdit(int id = 0, int taskid = 0)
        {
            BindCombo();
            //Permission_Staff model = new Permission_Staff();
            if (id == 0)
            {
                return View(new Division());
            }
            else
            {
                taskid = 6;
                HttpResponseMessage resp = GlobalVariables.client.GetAsync("GetDivision?id=" + id + "&taskid=" + taskid).Result;
                if (resp.IsSuccessStatusCode)
                {
                    var Deduction = resp.Content.ReadAsAsync<IEnumerable<Division>>().Result;
                    var record = Deduction.FirstOrDefault();
                    return View(record);
                }
                return View();
            }
        }

        [HttpPost]
        public ActionResult AddOrEdit(Division model)
        {
            BindCombo();
            if (model.ItbId == 0)
            {
                model.taskid = 2;
                HttpResponseMessage resp = GlobalVariables.client.PostAsJsonAsync("POSTDivision", model).Result;
                TempData["SuccessMessage"] = "Record Saved Successfully";
            }
            else
            {
                model.taskid = 4;
                HttpResponseMessage resp = GlobalVariables.client.PostAsJsonAsync("POSTDivision", model).Result;
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
        void BindCombo() {
            int id = 0; int taskid = 7;
            IEnumerable<State> StateList = null;
            HttpResponseMessage resp6 = GlobalVariables.client.GetAsync("GetState?id=" + id + "&taskid=" + taskid).Result;
            StateList = resp6.Content.ReadAsAsync<IEnumerable<State>>().Result;
            if (!Equals(StateList, null))
            {
                var sch = StateList.ToList();
                ViewBag.StateList = new SelectList(sch, "ItbId", "State_Name");
            }
        }
    }
}