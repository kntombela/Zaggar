using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Zaggar.Models
{
    public class Invoice
    {
        public int InvoiceID { get; set; }

        [Display(Name = "Invoice Date")]
        public DateTime InvoiceDate { get; set; }
        public int CustomerID { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual ICollection<InvoiceItem> InvoiceItems { get; set; }

    }
}