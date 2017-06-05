using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Zaggar.Models
{
    //Options for quote status
    public enum QuoteStatus
    {
        Accepted, Declined, New
    }

    public class Quote
    {
        public int QuoteID { get; set; }

        [Display(Name = "Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime QuoteDate { get; set; }

        [Display(Name = "Expiry Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime ExpiryDate { get; set; }
        public QuoteStatus? QuoteStatus { get; set; }

        [Display(Name = "Discount %")]
        [RegularExpression(@"^\d+\.\d{0,2}$")]
        [Range(0, 999.99)]
        public decimal Discount { get; set; }
        public int CustomerID { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual ICollection<QuoteItem> QuoteItems { get; set; }
    }
}