using SMP.app.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace SMP.Controllers
{
    public class FoodTTController : Controller
    {
        // GET: FoodTT
            IEnumerable<Food_Timetable> Food_TimetableList = null;
            public ActionResult Index(int id = 0, int taskid = 7)
            {
                try
                {
                    //IEnumerable<School_Details> SchoolDetailsList = null;

                    HttpResponseMessage resp = GlobalVariables.client.GetAsync("GetFood_Timetable?id=" + id + "&taskid=" + taskid).Result;
                    if (resp.IsSuccessStatusCode)
                    {
                    Food_TimetableList = resp.Content.ReadAsAsync<IEnumerable<Food_Timetable>>().Result;
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                    }
                    return View(Food_TimetableList);
                }
                catch (Exception ex)
                {

                    return View(ex.Message);
                }
            }

            public ActionResult AddOrEdit(int id = 0, int taskid = 0)
            {
            BindCombo();


            //Food_Timetable model = new Food_Timetable();
            if (id == 0)
                {
                    return View(new Food_Timetable());
                }
                else
                {
                    taskid = 6;
                    HttpResponseMessage resp = GlobalVariables.client.GetAsync("GetFood_Timetable?id=" + id + "&taskid=" + taskid).Result;
                    if (resp.IsSuccessStatusCode)
                    {
                        var foods = resp.Content.ReadAsAsync<IEnumerable<Food_Timetable>>().Result;
                        var record = foods.FirstOrDefault();
                        return View(record);
                    }
                    return View();
                }
            }

            [HttpPost]
            public ActionResult AddOrEdit(Food_Timetable model)
            {
            BindCombo();
                   
                if (model.ItbId == 0)
                {
                    model.taskid = 2;
                    HttpResponseMessage resp = GlobalVariables.client.PostAsJsonAsync("POSTFood_Timetable", model).Result;
                    TempData["SuccessMessage"] = "Record Saved Successfully";
                }
                else
                {
                    model.taskid = 4;
                    HttpResponseMessage resp = GlobalVariables.client.PostAsJsonAsync("POSTFood_Timetable", model).Result;
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
            IEnumerable<MenuType> MenuTypeList = null;
            HttpResponseMessage resp = GlobalVariables.client.GetAsync("GetMenuType?id=" + id + "&taskid=" + taskid).Result;
            MenuTypeList = resp.Content.ReadAsAsync<IEnumerable<MenuType>>().Result;
            if (!Equals(MenuTypeList, null))
            {
                var menutypes = MenuTypeList.ToList();
                ViewBag.MenuTypeList = new SelectList(menutypes, "ItbId", "Menu_Type");
            }

            IEnumerable<Day_Table> Day_TableList = null;
            HttpResponseMessage resp1 = GlobalVariables.client.GetAsync("GetDay_Table?id=" + id + "&taskid=" + taskid).Result;
            Day_TableList = resp1.Content.ReadAsAsync<IEnumerable<Day_Table>>().Result;
            if (!Equals(Day_TableList, null))
            {
                var dt = Day_TableList.ToList();
                ViewBag.Day_TableList = new SelectList(dt, "ItbId", "Day");
            }
        }



    }
}