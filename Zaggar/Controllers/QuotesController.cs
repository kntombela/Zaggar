using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Zaggar.DAL;
using Zaggar.Models;

namespace Zaggar.Controllers
{
    public class QuotesController : Controller
    {
        private ZaggarContext db = new ZaggarContext();

        // GET: Quotes
        public ActionResult Index()
        {
            var quotes = db.Quotes.Include(q => q.Customer);
            return View(quotes.ToList());
        }

        // GET: Quotes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Quote quote = db.Quotes.Find(id);
            if (quote == null)
            {
                return HttpNotFound();
            }
            return View(quote);
        }

        // GET: Quotes/Create
        public ActionResult Create()
        {
            //ViewBag.CustomerID = new SelectList(db.Customers, "CustomerID", "FirstName");
            PopulateCustomerDropDownList();
            return View();
        }

        // POST: Quotes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "QuoteID,QuoteDate,ExpiryDate,QuoteStatus,Discount,CustomerID")] Quote quote)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Quotes.Add(quote);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (RetryLimitExceededException /* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.)
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
            }
            
            PopulateCustomerDropDownList(quote.CustomerID);
            return View(quote);
        }

        // GET: Quotes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Quote quote = db.Quotes.Find(id);
            if (quote == null)
            {
                return HttpNotFound();
            }

            PopulateCustomerDropDownList(quote.CustomerID);
            return View(quote);
        }

        // POST: Quotes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public ActionResult EditPost(int? id)
        {
            //Checks if ID has been passed a parameter
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            //Bind model to update
            var quoteToUpdate = db.Quotes.Find(id);
            if (TryUpdateModel(quoteToUpdate, "",
                    new string[] { "QuoteDate", "ExpiryDate", "QuoteStatus", "Discount", "CustomerID" }))
            {
                try
                {
                    db.SaveChanges();

                    return RedirectToAction("Index");
                }
                catch (RetryLimitExceededException /* dex */)
                {
                    //Log the error (uncomment dex variable name and add a line here to write a log.
                    ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
                }
            }
            PopulateCustomerDropDownList(quoteToUpdate.CustomerID); ;
            return View(quoteToUpdate);
        }

        // GET: Quotes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Quote quote = db.Quotes.Find(id);
            if (quote == null)
            {
                return HttpNotFound();
            }
            return View(quote);
        }

        // POST: Quotes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Quote quote = db.Quotes.Find(id);
            db.Quotes.Remove(quote);
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


        //Customer Functions TODO: Move to service classes
        private void PopulateCustomerDropDownList(object selectedCustomer = null)
        {
            var customerQuery = db.Customers.OrderBy(c => c.LastName).ToList();
            ViewBag.CustomerID = new SelectList(customerQuery, "CustomerID", "LastName", selectedCustomer);
        }

        private void PopulateProductDropDownList(object selectedProduct = null)
        {
            var productQuery = db.Products.ToList();
            ViewBag.ProductID = new SelectList(productQuery, "ProductID", "Name", selectedProduct);
        }
    }
}
