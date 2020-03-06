
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PA1.Models;
namespace PA1.Controllers
{
    public class HomeController : Controller
    {
        DataContext db = new DataContext();
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index( Order collection)
        {
            
                try
                {
                string food = Request.Form["food"];

                // var dates = System.DateTime.Today.ToString("dd/MM/yy");

                var dt = DateTime.Now.Date; // or something like this
                var times = DateTime.Now;
                
                times = times.AddHours(1);
               var currentTime = times.ToString("hh: mm tt");




                // TODO: Add insert logic here
                List<object> newRecord = new List<object>();

                    newRecord.Add(food);

               
                newRecord.Add(dt);
                newRecord.Add(currentTime);
                newRecord.Add(Session["CustomerID"]);
                    object[] recordItem = newRecord.ToArray();
                
                

                if (Session["CustomerID"] != null)
                {
                    int result = db.Database.ExecuteSqlCommand("INSERT INTO orders " + "(FoodDescription,DeliveryDate,DeliveryTime,CustomerID,OrderStatus,ContactNumber)" + "VALUES(@p0,@p1,@p2,@p3,'Pending' ,000)", recordItem);
                    if (result > 0)
                    {
                        ViewBag.msg = " Orders record is added";
                    }
                    return RedirectToAction("Index", "Portal");
                }
                else
                {
                    return RedirectToAction("Index", "Login");
                }
            }
                catch
                {
                    return View();
                }
            
        }
    }
}