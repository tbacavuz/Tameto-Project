using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TOPOS.Data;
using TOPOS.Models;
using TOPOS.Models.Enums;

namespace TOPOS.Controllers
{
    public class HomeController : Controller
    {
        private TOPOSContext db = new TOPOSContext();

        public ActionResult Index()
        {
            HomeReturnResults homeReturn = new HomeReturnResults();
            homeReturn.Products = db.Products.Include(p => p.ProductTypes).ToList();
            homeReturn.ProductTypes = db.ProductTypes.ToList();

            return View(homeReturn);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        [HttpPost]
        public string CartChanged(long productId, int quantity)
        {
            if ((LoginType)Session["LoginType"] != LoginType.Customer)
            {
                return "LoginRequired";
            }

            var userId = (long)Session["LoginId"];

            var checkCart = db.Carts.FirstOrDefault(c => c.CustomerId == userId);

            if (checkCart is null)
            {
                db.CartDetails.Add(new CartDetails
                {
                    ProductId = productId,
                    Quantity = quantity,
                    Carts = new Carts
                    {
                        CustomerId = userId,
                    }
                });
            }
            else
            {
                var checkCatdDetails = db.CartDetails.Where(cd => cd.CartsId == checkCart.Id);
                var products = checkCatdDetails.FirstOrDefault(cd => cd.ProductId == productId);

                if (products is null)
                {
                    db.CartDetails.Add(new CartDetails
                    {
                        CartsId = checkCart.Id,
                        ProductId = productId,
                        Quantity = quantity
                    });
                }
                else
                {
                    products.Quantity = quantity;
                }
            }

            db.SaveChanges();

            return "Success";
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }

    public class HomeReturnResults
    {
        public List<Products> Products { get; set; }
        public List<ProductTypes> ProductTypes { get; set; }
    }
}