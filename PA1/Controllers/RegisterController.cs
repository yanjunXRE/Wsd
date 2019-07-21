using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PA1.Models;

namespace PA1.Controllers
{
    public class RegisterController : Controller
    {
        DataContext db = new DataContext();
        // GET: Register
        public ActionResult Index()
        {


            return View();
        }



        // POST: Portal/Create
        [HttpPost]
        public ActionResult Index(customer collection)
        {

            try
            {
                // TODO: Add insert logic here
                List<object> newRecord = new List<object>();

                newRecord.Add(collection.CustomerID);
                newRecord.Add(collection.Password);
                object[] recordItem = newRecord.ToArray();
                int result = db.Database.ExecuteSqlCommand("INSERT INTO customer " +  "VALUES(@p0,@p1)", recordItem);
              
                return RedirectToAction("Index","Login");
            }
            catch
            {
                return View();
            }
        }
    }
}
           
        
