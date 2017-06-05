using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Zaggar.Models
{
    public class Customer
    {
        
        public int CustomerID { get; set; }

        [Required]
        [Display(Name = "First Name")]
        [StringLength(50,ErrorMessage = "Firstname cannot be longer than 50 characters.")]
        public String FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        [StringLength(50, ErrorMessage = "Lastname cannot be longer than 50 characters.")]
        public String LastName { get; set; }

        [Required]
        public String Street { get; set; }

        public String Suburb { get; set; }

        [Required]
        public String City { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Country cannot be longer than 50 characters")]
        public String Country { get; set; }

        [Required]
        public double PostalCode { get; set; }
        public virtual ICollection<Invoice> Invoices { get; set; }
        public virtual ICollection<Quote> Quotes { get; set; }

    }
}