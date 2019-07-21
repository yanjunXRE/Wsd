using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PA1.Models;

namespace PA1.Controllers
{
    public class LoginController : Controller
    {
        DataContext db = new DataContext();
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(customer login)
        {
            try {
                List<object> newLogin = new List<object>();
                newLogin.Add(login.CustomerID);
                newLogin.Add(login.Password);

                object[] loginItems = newLogin.ToArray();
                var data = db.customer.SqlQuery("SELECT * FROM customer WHERE CustomerID=@p0 AND Password=@p1", loginItems).SingleOrDefault();
                
                if (data != null)
                {
                    Session["customerID"] = login.CustomerID.ToString();
                    return RedirectToAction( "Create","Portal");
                }
                else
                {
                    ViewBag.msg = "OrderID and/or Password is invalid";
                    return View();
                }
            }
            catch
            {
                return View();
            }
        }
    }
}