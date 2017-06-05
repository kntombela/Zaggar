using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Zaggar.Models
{
    public class Product
    {
        public int ProductID { get; set; }
        public string Name { get; set; }

        //[DataType(DataType.Currency)]
        //[Column(TypeName = "money")]
        public double Price { get; set; }

        [Display(Name = "Discount %")]
        [RegularExpression(@"^\d+\.\d{0,2}$")]
        [Range(0, 999.99)]
        public double VAT { get; set; }
    }
}