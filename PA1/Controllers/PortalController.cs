using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using PA1.Models;

namespace PA1.Controllers
{
    public class PortalController : Controller
    {

        // GET: Portal 
        DataContext db = new DataContext();
        public ActionResult Index()
        {
            if (Session["CustomerID"] != null)
            {
                
                var data = db.Order.SqlQuery("SELECT * FROM Orders Where CustomerID="+ Session["CustomerID"]).ToList();
                return View(data);

            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }
        public ActionResult LogOut()
        {
            Session.RemoveAll();
            return RedirectToAction("index", "Home");
        }
        public ActionResult Accepted()
        {
            if (Session["CustomerID"] != null)
            {
                var data = db.AcceptedOrder.SqlQuery("SELECT * FROM AcceptedOrders Where CustomerID=" + Session["CustomerID"]).ToList();
                return View(data);
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }
        // GET: Portal/Details/5
        public ActionResult Details(int id)
        {
            if (Session["CustomerID"] != null)
            {
                var data = db.Order.SqlQuery("Select * From Orders where OrderID=@p0", id).SingleOrDefault();
                return View(data);
            }

            else
            {
                return RedirectToAction("Index");

            }
        }



        // GET: Portal/Create
        public ActionResult Edit(int id)
        {
            if (Session["CustomerID"] != null) {
                var data = db.Order.SqlQuery("SELECT * FROM Orders WHERE OrderID =@p0", id).SingleOrDefault();
                return View(data);

            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        // POST: Portal/Create
        [HttpPost]
        public ActionResult Edit(int id, Order collection)
        { if (Session["CustomerID"] != null) {
                try
                {
                    // TODO: Add insert logic here
                    List<object> newRecord = new List<object>();

                    newRecord.Add(collection.FoodDescription);
                    newRecord.Add(collection.DeliveryAddress);
                    newRecord.Add(collection.DeliveryDate);
                    newRecord.Add(collection.DeliveryTime);
                    newRecord.Add(collection.EmailAddress);
                    newRecord.Add(collection.ContactNumber);
                    object[] recordItem = newRecord.ToArray();

                    int result = db.Database.ExecuteSqlCommand("UPDATE orders" + " SET FoodDescription=@p0,DeliveryAddress=@p1,DeliveryDate=@p2,DeliveryTime=@p3,EmailAddress=@p4,ContactNumber=@p5 " + "WHERE OrderID=" + id, recordItem);
                    if (result > 0)
                    {
                        ViewBag.msg = " Orders record is updated";
                    }
                    return View();
                }
                catch
                {
                    return View();
                }
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
        // GET: Portal/Delete/5
        public ActionResult Delete(int id)
        { if (Session["CustomerID"] != null) {
                var data = db.Order.SqlQuery("SELECT * FROM Orders WHERE OrderID=@p0", id).SingleOrDefault();
                return View(data);
            }

            else
            {
                return RedirectToAction("Index");
            }
        }

        // POST: Portal/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        { if (Session["CustomerID"] != null) {
                try
                {
                    // TODO: Add delete logic here
                    int result = db.Database.ExecuteSqlCommand("Delete FROM Orders WHERE  OrderID=@p0", id);
                    if (result > 0)
                    {

                        return RedirectToAction("Index");
                    }
                    return View();
                }
                catch
                {
                    return View();
                }
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
        public ActionResult Submit(int id)
        {
            if (Session["CustomerID"] != null)
            {
                var data = db.Order.SqlQuery("SELECT * FROM Orders WHERE OrderID=@p0", id).SingleOrDefault();
                return View(data);
            }

            else
            {
                return RedirectToAction("Index");
            }
        }

        // POST: Portal/Delete/5
        [HttpPost]
        public ActionResult Submit(int id, Order collection)
        {
            if (Session["CustomerID"] != null)
            {
                try
                {
                    // TODO: Add delete logic here
                   
                    List<object> newRecord = new List<object>();

                    newRecord.Add(collection.FoodDescription);
                    newRecord.Add(collection.DeliveryAddress);
                    newRecord.Add(collection.DeliveryDate);
                    newRecord.Add(collection.DeliveryTime);
                    newRecord.Add(collection.EmailAddress);
                    newRecord.Add(collection.ContactNumber);
                    newRecord.Add("Accepted");
                    newRecord.Add(collection.CustomerID);


                    object[] recordItem = newRecord.ToArray();

                        int results = db.Database.ExecuteSqlCommand("INSERT INTO AcceptedOrders"+ "(FoodDescription,DeliveryAddress,DeliveryDate,DeliveryTime,EmailAddress,ContactNumber,OrderStatus,CustomerID)" + " VALUES(@p0,@p1,@p2,@p3,@p4,@p5,@p6,@p7)" , recordItem);
                  //  int results = db.Database.ExecuteSqlCommand("INSERT INTO AcceptedOrders" + "(DeliveryDateTIme,ContactNumber,CustomerID)" + " VALUES(@p2,@p4,@p6)", recordItem);
                    int result = db.Database.ExecuteSqlCommand("Delete FROM Orders WHERE  OrderID= " + id);


                    if (result>0)
                    {
                        return RedirectToAction("Accepted");
                    }
                    return View();
                }
                catch
                {
                    return View();
                }
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
    
    }
}
