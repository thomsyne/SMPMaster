﻿using SMP.app.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace SMP.Controllers.Admin
{
    public class ClassController : Controller
    {
        // GET: Class
        public ActionResult Index(int id = 0, int taskid = 7)
        {
            try
            {
                IEnumerable<Class> ClassList = null;

                HttpResponseMessage resp = GlobalVariables.client.GetAsync("GetClass?id=" + id + "&taskid=" + taskid).Result;
                if (resp.IsSuccessStatusCode)
                {
                    ClassList = resp.Content.ReadAsAsync<IEnumerable<Class>>().Result;
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                }
                return View(ClassList);
            }
            catch (Exception ex)
            {

                return View(ex.Message);
            }
        }

        public ActionResult AddOrEdit(int id = 0, int taskid = 0)
        {
            BindCombo();
            //Class model = new Class();
            if (id == 0)
            {
                return View(new Class());
            }
            else
            {
                taskid = 6;
                HttpResponseMessage resp = GlobalVariables.client.GetAsync("GetClass?id=" + id + "&taskid=" + taskid).Result;
                if (resp.IsSuccessStatusCode)
                {
                    var classes = resp.Content.ReadAsAsync<IEnumerable<Class>>().Result;
                    var record = classes.FirstOrDefault();
                    return View(record);
                }
                return View();
            }
        }

        [HttpPost]
        public ActionResult AddOrEdit(Class model)
        {
            BindCombo();

            if (model.ItbId == 0)

            {
                model.taskid = 2;
                HttpResponseMessage resp = GlobalVariables.client.PostAsJsonAsync("POSTClass", model).Result;
                TempData["SuccessMessage"] = "Record Saved Successfully";
            }
            else
            {
                model.taskid = 4;
                HttpResponseMessage resp = GlobalVariables.client.PostAsJsonAsync("POSTClass", model).Result;
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
            IEnumerable<Program> ProgramList = null;
            HttpResponseMessage resp = GlobalVariables.client.GetAsync("GetProgram?id=" + id + "&taskid=" + taskid).Result;
            ProgramList = resp.Content.ReadAsAsync<IEnumerable<Program>>().Result;
            if (!Equals(ProgramList, null))
            {
                var programs = ProgramList.ToList();
                ViewBag.ProgramList = new SelectList(programs, "ItbId", "Program_Name");
            }

            IEnumerable<School_Details> School_DetailsList = null;
            HttpResponseMessage resp1 = GlobalVariables.client.GetAsync("GetSchool_Details?id=" + id + "&taskid=" + taskid).Result;
            School_DetailsList = resp1.Content.ReadAsAsync<IEnumerable<School_Details>>().Result;
            if (!Equals(School_DetailsList, null))
            {
                var school = School_DetailsList.ToList();
                ViewBag.School_DetailsList = new SelectList(school, "ItbId", "Name");
            }

        }
    }
}