using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Zaggar.Models
{
    public class QuoteItem
    {
        [Key]
        public int Item { get; set; }
        public int Quantity { get; set; }
        public int QuoteID { get; set; }
        public int ProductID { get; set; }
        public virtual Quote Quote { get; set; }
        public virtual Product Product { get; set; }
    }
}