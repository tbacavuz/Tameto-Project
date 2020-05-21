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
using TOPOS.Models.Enums;

namespace TOPOS.Controllers
{
    public class UserLoginController : Controller
    {
        private TOPOSContext db = new TOPOSContext();

        // GET: UserLogin
        public ActionResult Index()
        {
            return View();
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index([Bind(Include = "Id,Username,Password")] Users users)
        {
            if (string.IsNullOrEmpty(users.Username) || string.IsNullOrEmpty(users.Password))
            {
                ViewBag.Error = "Please fill in the blanks";
                return View("Index", users);
            }
            var getUser = db.Users.FirstOrDefault(x => x.Username == users.Username);
            if (getUser != null)
            {
                if (getUser.Password == users.Password)
                {
                    Session["LoginId"] = getUser.Id;
                    Session["LoginType"] = LoginType.User;
                    Session["RoleType"] = (RolesTypes)getUser.RolesId;
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

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
