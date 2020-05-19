using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TOPOS.Data;
using TOPOS.Models;

namespace TOPOS.Controllers
{
    public class CustomerLoginController : Controller
    {
        private TOPOSContext db = new TOPOSContext();

        // GET: CustomerLogin
        public ActionResult Index()
        {
            return View();
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index([Bind(Include = "Id,Email,Password")] Customers customers)
        {
            if(string.IsNullOrEmpty(customers.Email) || string.IsNullOrEmpty(customers.Password))
            {
                ViewBag.Error = "Please fill in the blanks";
                return View("Index", customers);
            }
            var getUser = db.Customers.FirstOrDefault(x => x.Email == customers.Email);
            if (getUser != null)
            {
                if (getUser.Password == customers.Password)
                {
                    Session["Id"] = getUser.Id;
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ViewBag.Error = "Invalid Password.";
                }
            }
            else
                ViewBag.Error = "User does not exist.";

            return View("Index");
        }
    }

}
