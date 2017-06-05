using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Zaggar.Models
{
    public class InvoiceItem
    {
        [Key]
        public int Item { get; set; }
        public int Quantity { get; set; }
        public int InvoiceID { get; set; }
        public int ProductID { get; set; }
        public virtual Invoice Invoice { get; set; }
        public virtual Product Product { get; set; }

    }
}