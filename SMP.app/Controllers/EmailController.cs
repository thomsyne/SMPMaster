//using SM.Models;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Net.Http;
//using System.Web;
//using System.Web.Mvc;

//namespace SM.Controllers.Admin
//{
//    public class EmailController : Controller
//    {
//        // GET: Email
//        public ActionResult Index(int id = 0, int taskid = 7)
//        {
//            try
//            {
//                IEnumerable<Email> EmailList = null;

//                HttpResponseMessage resp = GlobalVariables.client.GetAsync("Email?id=" + id + "&taskid=" + taskid).Result;
//                if (resp.IsSuccessStatusCode)
//                {
//                    EmailList = resp.Content.ReadAsAsync<IEnumerable<Email>>().Result;
//                }
//                else
//                {
//                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
//                }
//                return View(EmailList);
//            }
//            catch (Exception ex)
//            {

//                return View(ex.Message);
//            }
//        }

//        public ActionResult AddOrEdit(int id = 0, int taskid = 0)
//        {
//            //Email model = new Email();
//            if (id == 0)
//            {
//                return View(new Email());
//            }
//            else
//            {
//                taskid = 5;
//                HttpResponseMessage resp = GlobalVariables.client.GetAsync("GetEmail?id=" + id + "&taskid=" + taskid).Result;
//                return View(resp.Content.ReadAsAsync<Email>().Result);
//            }
//            //return View();
//        }

//        [HttpPost]
//        public ActionResult AddOrEdit(Email model)
//        {

//            if (model.ItbId == 0)
//            {
//                model.taskid = 2;
//                HttpResponseMessage resp = GlobalVariables.client.PostAsJsonAsync("POSTEmail", model).Result;
//                TempData["SuccessMessage"] = "Record Saved Successfully";
//            }
//            else
//            {
//                model.taskid = 4;
//                HttpResponseMessage resp = GlobalVariables.client.PostAsJsonAsync("POSTEmail", model).Result;
//                TempData["SuccessMessage"] = "Record Updated Successfully";
//            }
//            return RedirectToAction("Index");
//        }

//        //public ActionResult Delete(int id)
//        //{
//        //    HttpResponseMessage resp = GlobalVariables.client.DeleteAsync("http://localhost/schoolwebapi/" + id.ToString()).Result;
//        //    TempData["SuccessMessage"] = "Record Deleted Successfully";
//        //    return RedirectToAction("Index");
//        //}
//    }
//}