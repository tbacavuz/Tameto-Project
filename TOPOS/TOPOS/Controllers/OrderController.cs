using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TOPOS.Controllers
{
    public class OrderController : Controller
    {
        // GET: Order
        public ActionResult Menu()
        {
            return View();
        }

        public ActionResult ViewCart()
        {

            return View();
        }

        
        }
    }
