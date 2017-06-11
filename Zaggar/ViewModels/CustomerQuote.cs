using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Zaggar.Models;

namespace Zaggar.ViewModels
{
    public class CustomerQuote
    {
        public IEnumerable<Customer> Customers { get; set; }
        public IEnumerable<Quote> Quotes { get; set; }
        public IEnumerable<QuoteItem> QuoteItems { get; set; }
        public IEnumerable<Product> Products { get; set; }
    }
}