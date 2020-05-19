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
    public class ProductTypesController : Controller
    {
        private TOPOSContext db = new TOPOSContext();

        // GET: ProductTypes
        public ActionResult Index()
        {
            return View(db.ProductTypes.ToList());
        }

        // GET: ProductTypes/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductTypes productTypes = db.ProductTypes.Find(id);
            if (productTypes == null)
            {
                return HttpNotFound();
            }
            return View(productTypes);
        }

        // GET: ProductTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name")] ProductTypes productTypes)
        {
            if (ModelState.IsValid)
            {
                db.ProductTypes.Add(productTypes);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(productTypes);
        }

        // GET: ProductTypes/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductTypes productTypes = db.ProductTypes.Find(id);
            if (productTypes == null)
            {
                return HttpNotFound();
            }
            return View(productTypes);
        }

        // POST: ProductTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name")] ProductTypes productTypes)
        {
            if (ModelState.IsValid)
            {
                db.Entry(productTypes).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(productTypes);
        }

        // GET: ProductTypes/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductTypes productTypes = db.ProductTypes.Find(id);
            if (productTypes == null)
            {
                return HttpNotFound();
            }
            return View(productTypes);
        }

        // POST: ProductTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            ProductTypes productTypes = db.ProductTypes.Find(id);
            db.ProductTypes.Remove(productTypes);
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
