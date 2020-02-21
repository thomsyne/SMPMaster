using SMP.app.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace SMP.Controllers.Admin
{
    public class LoginAuditController : Controller
    {
        // GET: Campus
        public ActionResult Index(int id = 0, int taskid = 7)
        {
            try
            {
                IEnumerable<LoginAudit> LoginAuditList = null;

                HttpResponseMessage resp = GlobalVariables.client.GetAsync("GetLoginAudit?id=" + id + "&taskid=" + taskid).Result;
                if (resp.IsSuccessStatusCode)
                {
                    LoginAuditList = resp.Content.ReadAsAsync<IEnumerable<LoginAudit>>().Result;
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                }
                return View(LoginAuditList);
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
                return View(new LoginAudit());
            }
            else
            {
                taskid = 6;
                HttpResponseMessage resp = GlobalVariables.client.GetAsync("GetLoginAudit?id=" + id + "&taskid=" + taskid).Result;
                if (resp.IsSuccessStatusCode)
                {
                    var LoginAudit = resp.Content.ReadAsAsync<IEnumerable<LoginAudit>>().Result;
                    var record = LoginAudit.FirstOrDefault();
                    return View(record);
                }
                return View();
            }
        }

        [HttpPost]
        public ActionResult AddOrEdit(LoginAudit model)
        {
            BindCombo();
            if (model.ItbId == 0)
            {
                model.taskid = 2;
                HttpResponseMessage resp = GlobalVariables.client.PostAsJsonAsync("POSTLoginAudit", model).Result;
                TempData["SuccessMessage"] = "Record Saved Successfully";
            }
            else
            {
                model.taskid = 4;
                HttpResponseMessage resp = GlobalVariables.client.PostAsJsonAsync("POSTLoginAudit", model).Result;
                TempData["SuccessMessage"] = "Record Updated Successfully";
            }
            return RedirectToAction("Index");
        }

        void BindCombo()
        {
            int id = 0; int taskid = 7;
            IEnumerable<Users> UsersList = null;
            HttpResponseMessage resp1 = GlobalVariables.client.GetAsync("GetUsers?id=" + id + "&taskid=" + taskid).Result;
            UsersList = resp1.Content.ReadAsAsync<IEnumerable<Users>>().Result;
            if (!Equals(UsersList, null))
            {
                var programs = UsersList.ToList();
                ViewBag.UsersList = new SelectList(programs, "ItbId", "Username");
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