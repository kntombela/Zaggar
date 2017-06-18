using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Zaggar.DAL;
using Zaggar.ViewModels;
using System.Data.Entity;

namespace Zaggar.Controllers
{
    public class CustomerQuotesController : Controller
    {
        ZaggarContext db = new ZaggarContext();
        // GET: CustomerQuotes
        public ActionResult Index()
        {
            //var viewModel = new CustomerQuoteViewModel();
            //viewModel.Quotes = db.Quotes.Include(q => q.Customer).Include(q => q.QuoteItems).ToList();
            //viewModel.Total = viewModel.QuoteItems.Sum(q => q.Quantity);

            //Propulate CustomerQuotes View model
            var viewModel = db.Quotes
                            .Include("Customer")
                            .Include("QuoteItems")
                            .ToList()//The ToList method performs the fetch to the database and allows the results to be asssigned
                            .Select(q => new CustomerQuoteViewModel {
                                Customer = q.Customer,
                                Quote = q,
                                Total = q.QuoteItems.Sum(qi => qi.Total)
                            });
            
            return View(viewModel);
        }
    }
}