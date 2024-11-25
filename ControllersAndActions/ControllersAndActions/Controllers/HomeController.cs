using System;
using ControllersAndActions.Models;
using Microsoft.AspNetCore.Mvc;

namespace ControllersAndActions.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            TempData["color_combination"] = "yellow";
            TempData.Keep();
            return View();
        }
        public IActionResult About()
        {
            return View();
        }
        public IActionResult Contact()
        {
            return View();
        }
        public IActionResult ControllerToViewAsViewData()
        {

            ViewData["name"] = "Rohit";
            ViewData["age"] = "24";
            ViewData["mobile_no"] = "9351163747";
            ViewData["today_date"] = DateTime.Now.ToLongDateString();
            string[] arr = { "Manish", "Rajesh", "Ashok" };
            ViewData["friends"] = arr;

            ViewData["fav_places"] = new List<string>()
            {
                "Rajasthan","Delhi","Manali"
            };
            return View();
        }
        public IActionResult ControllerToViewAsViewBag()
        {
            ViewBag.name = "Rohit";
            ViewBag.age = "24";
            ViewBag.mobile_no = "9351163747";
            ViewBag.today_date = DateTime.Now.ToLongDateString();
            string[] arr = { "Manish", "Rajesh", "Ashok" };
            ViewBag.friends = arr;

            ViewBag.fav_places = new List<string>()
            {
                "Rajasthan","Delhi","Manali"
            };


            // we can do like this also
            ViewData["fav_color"] = "White";
            ViewBag.bad_color = "purple";

            return View();
        }
        public IActionResult ControllerToViewAsTempView()
        {
            TempData["color_combination"] = "yellow";
            ViewData["fav_color"] = "White";
            ViewBag.bad_color = "purple";
            TempData.Keep();        // we can pass the data or Not both will fine
            //TempData.Keep("color_combination");    // like that we can pass the data also
            return View();
        }
        public IActionResult ControllerToViewAsStronglyTypedViews()
        {
            Employee obj = new Employee()
            {
                EmpId = 1,
                EmpName = "Rohit",
                Designation = "Manager",
                Salary = 45000

            };
            return View(obj);
        }
    }
}
