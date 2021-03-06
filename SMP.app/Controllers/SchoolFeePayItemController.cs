﻿using SMP.app.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace SMP.Controllers.Admin
{
    public class SchoolFeePayItemController : Controller
    {
        // GET: SchoolFeePayItem
        public ActionResult Index(int id = 0, int taskid = 7)
        {
            try
            {
                IEnumerable<SchoolFeePayItem> SchoolFeePayItemList = null;

                HttpResponseMessage resp = GlobalVariables.client.GetAsync("GetSchoolFeePayItem?id=" + id + "&taskid=" + taskid).Result;
                if (resp.IsSuccessStatusCode)
                {
                    SchoolFeePayItemList = resp.Content.ReadAsAsync<IEnumerable<SchoolFeePayItem>>().Result;
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                }
                return View(SchoolFeePayItemList);
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
                return View(new SchoolFeePayItem());
            }
            else
            {
                taskid = 6;
                HttpResponseMessage resp = GlobalVariables.client.GetAsync("GetSchoolFeePayItem?id=" + id + "&taskid=" + taskid).Result;
                if (resp.IsSuccessStatusCode)
                {
                    var schoolfeepayitem = resp.Content.ReadAsAsync<IEnumerable<SchoolFeePayItem>>().Result;
                    var record = schoolfeepayitem.FirstOrDefault();
                    return View(record);
                }
                return View();
            }
        }

        [HttpPost]
        public ActionResult AddOrEdit(SchoolFeePayItem model)
        {

            if (model.ItbId == 0)
            {
                model.taskid = 2;
                HttpResponseMessage resp = GlobalVariables.client.PostAsJsonAsync("POSTSchoolFeePayItem", model).Result;
                TempData["SuccessMessage"] = "Record Saved Successfully";
            }
            else
            {
                model.taskid = 4;
                HttpResponseMessage resp = GlobalVariables.client.PostAsJsonAsync("POSTSchoolFeePayItem", model).Result;
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