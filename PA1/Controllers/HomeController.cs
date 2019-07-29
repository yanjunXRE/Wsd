
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
                
                DateTime dt = DateTime.Now; // or something like this
                dt = dt.AddHours(1);
                

                

                // TODO: Add insert logic here
                List<object> newRecord = new List<object>();

                    newRecord.Add(food);

               
                newRecord.Add(dt);
                newRecord.Add(Session["CustomerID"]);
                    object[] recordItem = newRecord.ToArray();
                
                

                if (Session["CustomerID"] != null)
                {
                    int result = db.Database.ExecuteSqlCommand("INSERT INTO orders " + "(FoodDescription,DeliveryDateTIme,CustomerID,OrderStatus,ContactNumber)" + "VALUES(@p0,@p1,@p2,'Pending' ,000)", recordItem);
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