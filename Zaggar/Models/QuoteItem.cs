using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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

        public Double Exclusive
        {
            get
            {
                return (Quantity * Product.Price);
            }
        }

        public Double VAT
        {
            get
            {
                return (Exclusive * 0.14);
            }

        }

        public Double Total
        {
            get
            {
                return (Exclusive + VAT);
            }
        }

    }
}