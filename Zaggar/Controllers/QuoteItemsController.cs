﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Zaggar.DAL;
using Zaggar.Models;

namespace Zaggar.Controllers
{
    public class QuoteItemsController : Controller
    {
        private ZaggarContext db = new ZaggarContext();

        // GET: QuoteItems
        public ActionResult Index()
        {
            var quoteItems = db.QuoteItems.Include(q => q.Product).Include(q => q.Quote);
            return View(quoteItems.ToList());
        }

        // GET: QuoteItems/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QuoteItem quoteItem = db.QuoteItems.Find(id);
            if (quoteItem == null)
            {
                return HttpNotFound();
            }
            return View(quoteItem);
        }

        // GET: QuoteItems/Create
        public ActionResult Create()
        {
            ViewBag.ProductID = new SelectList(db.Products, "ProductID", "Name");
            ViewBag.QuoteID = new SelectList(db.Quotes, "QuoteID", "QuoteID");
            return View();
        }

        // POST: QuoteItems/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Item,Quantity,QuoteID,ProductID")] QuoteItem quoteItem)
        {
            if (ModelState.IsValid)
            {
                db.QuoteItems.Add(quoteItem);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProductID = new SelectList(db.Products, "ProductID", "Name", quoteItem.ProductID);
            ViewBag.QuoteID = new SelectList(db.Quotes, "QuoteID", "QuoteID", quoteItem.QuoteID);
            return View(quoteItem);
        }

        // GET: QuoteItems/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QuoteItem quoteItem = db.QuoteItems.Find(id);
            if (quoteItem == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProductID = new SelectList(db.Products, "ProductID", "Name", quoteItem.ProductID);
            ViewBag.QuoteID = new SelectList(db.Quotes, "QuoteID", "QuoteID", quoteItem.QuoteID);
            return View(quoteItem);
        }

        // POST: QuoteItems/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Item,Quantity,QuoteID,ProductID")] QuoteItem quoteItem)
        {
            if (ModelState.IsValid)
            {
                db.Entry(quoteItem).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProductID = new SelectList(db.Products, "ProductID", "Name", quoteItem.ProductID);
            ViewBag.QuoteID = new SelectList(db.Quotes, "QuoteID", "QuoteID", quoteItem.QuoteID);
            return View(quoteItem);
        }

        // GET: QuoteItems/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QuoteItem quoteItem = db.QuoteItems.Find(id);
            if (quoteItem == null)
            {
                return HttpNotFound();
            }
            return View(quoteItem);
        }

        // POST: QuoteItems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            QuoteItem quoteItem = db.QuoteItems.Find(id);
            db.QuoteItems.Remove(quoteItem);
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
