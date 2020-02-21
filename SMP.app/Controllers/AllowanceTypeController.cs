using SMP.app.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace SMP.Controllers.Admin
{
    public class AllowanceTypeController : Controller
    {
        // GET: AllowanceType
        public ActionResult Index(int id = 0, int taskid = 7)
        {
            try
            {
                IEnumerable<AllowanceType> AllowanceTypeList = null;

                HttpResponseMessage resp = GlobalVariables.client.GetAsync("GetAllowanceType?id=" + id + "&taskid=" + taskid).Result;
                if (resp.IsSuccessStatusCode)
                {
                    AllowanceTypeList = resp.Content.ReadAsAsync<IEnumerable<AllowanceType>>().Result;
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                }
                return View(AllowanceTypeList);
            }
            catch (Exception ex)
            {

                return View(ex.Message);
            }
        }

        public ActionResult AddOrEdit(int id = 0, int taskid = 0)
        {
           
            if (id == 0)
            {
                return View(new AllowanceType());
            }
            else
            {
                taskid = 6;
                HttpResponseMessage resp = GlobalVariables.client.GetAsync("GetAllowanceType?id=" + id + "&taskid=" + taskid).Result;
                if (resp.IsSuccessStatusCode)
                {
                    var AllowanceType = resp.Content.ReadAsAsync<IEnumerable<AllowanceType>>().Result;
                    var record = AllowanceType.FirstOrDefault();
                    return View(record);
                }
                return View();
            }
        }

        [HttpPost]
        public ActionResult AddOrEdit(AllowanceType model)
        {
            if (model.ItbId == 0)
            {
                model.taskid = 2;
                HttpResponseMessage resp = GlobalVariables.client.PostAsJsonAsync("POSTAllowanceType", model).Result;
                TempData["SuccessMessage"] = "Record Saved Successfully";
            }
            else
            {
                model.taskid = 4;
                HttpResponseMessage resp = GlobalVariables.client.PostAsJsonAsync("POSTAllowanceType", model).Result;
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