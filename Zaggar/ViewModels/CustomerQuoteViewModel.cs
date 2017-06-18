using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Zaggar.Models;

namespace Zaggar.ViewModels
{
    public class CustomerQuoteViewModel
    {
        //public IEnumerable<Customer> Customer { get; set; }
        //public IEnumerable<Quote> Quotes { get; set; }
        //public IEnumerable<QuoteItem> QuoteItems { get; set; }
        //public Double Total { get; set; }
        //public Double Total { get { return QuoteItems.Sum(q => q.Total); } }
        //public Product Products { get; set; }

        public Customer Customer { get; set; }
        public Quote Quote { get; set; }
        public Double Total { get; set; }
        public String FullName { get { return Customer.FirstName + ' ' + Customer.LastName; } }
    }
}