using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FoodFinder.Models;

namespace FoodFinder.Controllers
{
    public class PriceWatchEntryController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: PriceWatchEntry
        public ActionResult Index()
        {
            return View(db.PriceWatchEntries.ToList());
        }

        // GET: PriceWatchEntry/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PriceWatchEntry priceWatchEntry = db.PriceWatchEntries.Find(id);
            if (priceWatchEntry == null)
            {
                return HttpNotFound();
            }
            return View(priceWatchEntry);
        }

        // GET: PriceWatchEntry/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PriceWatchEntry/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Date,Price,PriceIndicator")] PriceWatchEntry priceWatchEntry)
        {
            if (ModelState.IsValid)
            {
                db.PriceWatchEntries.Add(priceWatchEntry);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(priceWatchEntry);
        }

        // GET: PriceWatchEntry/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PriceWatchEntry priceWatchEntry = db.PriceWatchEntries.Find(id);
            if (priceWatchEntry == null)
            {
                return HttpNotFound();
            }
            return View(priceWatchEntry);
        }

        // POST: PriceWatchEntry/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Date,Price,PriceIndicator")] PriceWatchEntry priceWatchEntry)
        {
            if (ModelState.IsValid)
            {
                db.Entry(priceWatchEntry).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(priceWatchEntry);
        }

        // GET: PriceWatchEntry/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PriceWatchEntry priceWatchEntry = db.PriceWatchEntries.Find(id);
            if (priceWatchEntry == null)
            {
                return HttpNotFound();
            }
            return View(priceWatchEntry);
        }

        // POST: PriceWatchEntry/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            PriceWatchEntry priceWatchEntry = db.PriceWatchEntries.Find(id);
            db.PriceWatchEntries.Remove(priceWatchEntry);
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
