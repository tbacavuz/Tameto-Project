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
    public class CartDetailsController : Controller
    {
        private TOPOSContext db = new TOPOSContext();

        // GET: CartDetails
        public ActionResult Index()
        {
            var userId = (long)Session["LoginId"];

            var carts = db.Carts.FirstOrDefault(c => c.CustomerId == userId);
            var cartDetails = db.CartDetails.Where(cd => cd.CartsId == carts.Id).Include(c => c.Products);

            return View(cartDetails.ToList());
        }

        public ActionResult SubmitCart()
        {
            var userId = (long)Session["LoginId"];
            var carts = db.Carts.FirstOrDefault(c => c.CustomerId == userId);
            var cartDetails = db.CartDetails.Where(cd => cd.CartsId == carts.Id).Include(c => c.Products);

            var order = db.Orders.Add(new Orders { CustomersId = userId, Date = DateTime.UtcNow });
            foreach (var detail in cartDetails) 
            {
                db.OrderDetails.Add(new OrderDetails { ProductId = detail.ProductId, Quantity = detail.Quantity, OrderId = order.Id });
            }

            db.Carts.Remove(carts);
            db.SaveChanges();

            return RedirectToAction("Index", "OrderDetails");
        }




        // GET: CartDetails/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CartDetails cartDetails = db.CartDetails.Find(id);
            if (cartDetails == null)
            {
                return HttpNotFound();
            }
            return View(cartDetails);
        }

        // GET: CartDetails/Create
        public ActionResult Create()
        {
            ViewBag.CartsId = new SelectList(db.Carts, "Id", "Id");
            ViewBag.ProductId = new SelectList(db.Products, "Id", "Name");
            return View();
        }

        // POST: CartDetails/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Quantity,CartsId,ProductId")] CartDetails cartDetails)
        {
            if (ModelState.IsValid)
            {
                db.CartDetails.Add(cartDetails);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CartsId = new SelectList(db.Carts, "Id", "Id", cartDetails.CartsId);
            ViewBag.ProductId = new SelectList(db.Products, "Id", "Name", cartDetails.ProductId);
            return View(cartDetails);
        }

        // GET: CartDetails/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CartDetails cartDetails = db.CartDetails.Find(id);
            if (cartDetails == null)
            {
                return HttpNotFound();
            }
            ViewBag.CartsId = new SelectList(db.Carts, "Id", "Id", cartDetails.CartsId);
            ViewBag.ProductId = new SelectList(db.Products, "Id", "Name", cartDetails.ProductId);
            return View(cartDetails);
        }

        // POST: CartDetails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Quantity,CartsId,ProductId")] CartDetails cartDetails)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cartDetails).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CartsId = new SelectList(db.Carts, "Id", "Id", cartDetails.CartsId);
            ViewBag.ProductId = new SelectList(db.Products, "Id", "Name", cartDetails.ProductId);
            return View(cartDetails);
        }

        // GET: CartDetails/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CartDetails cartDetails = db.CartDetails.Find(id);
            if (cartDetails == null)
            {
                return HttpNotFound();
            }
            return View(cartDetails);
        }

        // POST: CartDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            CartDetails cartDetails = db.CartDetails.Find(id);
            db.CartDetails.Remove(cartDetails);
            db.SaveChanges();
            return RedirectToAction("Index");
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
