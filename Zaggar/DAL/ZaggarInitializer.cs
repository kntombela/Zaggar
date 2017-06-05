using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Zaggar.Models;

namespace Zaggar.DAL
{
    public class ZaggarInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<ZaggarContext>
    {
        protected override void Seed(ZaggarContext context)
        {

            //Dummy Customer Data
            var customer = new List<Customer>
            {
            new Customer{FirstName="Carson",LastName="Alexander",Street="53 Vilakazi Street", City ="Johannesburg", Country="South Africa", Suburb ="Johannesburg A", PostalCode = 1201},
            new Customer{FirstName="Meredith",LastName="Alonso",Street="12 Mitchel Place", City ="Sandton", Country="South Africa", Suburb ="Alexander", PostalCode = 1452},
            new Customer{FirstName="Arturo",LastName="Anand",Street="8 President Street", City ="Sandton", Country="South Africa", Suburb ="Buccleugh", PostalCode = 9854},
            new Customer{FirstName="Gytis",LastName="Barzdukas",Street="78 Main Road", City ="Fourways", Country="South Africa", Suburb ="Lonehill", PostalCode = 8954},
            new Customer{FirstName="Yan",LastName="Li",Street="826 Mineer Street", City ="Fourways", Country="South Africa", Suburb ="Douglasdale", PostalCode = 1835},
            new Customer{FirstName="Peggy",LastName="Justice",Street="44 Baker Street", City ="Cape Town", Country="South Africa", Suburb ="Tableview", PostalCode = 8824},
            new Customer{FirstName="Laura",LastName="Norman",Street="141 Steve Biko Crescent", City ="Johannesburg", Country="South Africa", Suburb ="Dinwiddie", PostalCode = 6489},
            new Customer{FirstName="Nino",LastName="Olivetto",Street="879 Jan Smuts Street", City ="Durban", Country="South Africa", Suburb ="Umhlanga", PostalCode = 5641}
            };

            customer.ForEach(c => context.Customers.Add(c));
            context.SaveChanges();

            var product = new List<Product>
            {
            new Product{Name="Chair",Price=105,VAT = 0.14},
            new Product{Name="Sofa",Price=402,VAT = 0.14},
            new Product{Name="Pillow",Price=40,VAT = 0.14},
            new Product{Name="Sleep Couch",Price=1045,VAT = 0.14},
            new Product{Name="Table",Price=3141,VAT = 0.14},
            new Product{Name="Stool",Price=202,VAT = 0.14},
            new Product{Name="Bunk Bed",VAT = 0.14},
            new Product{Name="Bed",Price=1050,},
            new Product{Name="Head Board",Price=402,VAT = 0.14},
            new Product{Name="Mirror",Price=40,VAT = 0.14},
            new Product{Name="Shelf",Price=104,VAT = 0.14},
            new Product{Name="Desk",Price=314,VAT = 0.14},
            };
            product.ForEach(p => context.Products.Add(p));
            context.SaveChanges();

            var invoice = new List<Invoice>
            {
            new Invoice{CustomerID=1,InvoiceDate=DateTime.Parse("2017-06-01")},
            new Invoice{CustomerID=1,InvoiceDate=DateTime.Parse("2017-06-02")},
            new Invoice{CustomerID=1,InvoiceDate=DateTime.Parse("2017-06-03")},
            new Invoice{CustomerID=2,InvoiceDate=DateTime.Parse("2017-06-04")},
            new Invoice{CustomerID=2,InvoiceDate=DateTime.Parse("2017-05-11")},
            new Invoice{CustomerID=2,InvoiceDate=DateTime.Parse("2017-05-22")},
            new Invoice{CustomerID=3,InvoiceDate=DateTime.Parse("2017-05-30")},
            new Invoice{CustomerID=4,InvoiceDate=DateTime.Parse("2017-06-01")},
            new Invoice{CustomerID=4,InvoiceDate=DateTime.Parse("2017-06-05")},
            new Invoice{CustomerID=5,InvoiceDate=DateTime.Parse("2017-06-06")},
            new Invoice{CustomerID=6,InvoiceDate=DateTime.Parse("2017-06-06")},
            new Invoice{CustomerID=7,InvoiceDate=DateTime.Parse("2017-05-31")},
            };
            invoice.ForEach(i => context.Invoices.Add(i));
            context.SaveChanges();

            var quote = new List<Quote>
            {
            new Quote{CustomerID=1,QuoteDate=DateTime.Parse("2017-06-01"),ExpiryDate=DateTime.Parse("2017-06-02"),QuoteStatus = QuoteStatus.New},
            new Quote{CustomerID=1,QuoteDate=DateTime.Parse("2017-06-02"),ExpiryDate=DateTime.Parse("2017-06-03"),QuoteStatus = QuoteStatus.Accepted},
            new Quote{CustomerID=1,QuoteDate=DateTime.Parse("2017-06-03"),ExpiryDate=DateTime.Parse("2017-06-04"),QuoteStatus = QuoteStatus.New},
            new Quote{CustomerID=2,QuoteDate=DateTime.Parse("2017-06-04"),ExpiryDate=DateTime.Parse("2017-06-05"),QuoteStatus = QuoteStatus.New},
            new Quote{CustomerID=2,QuoteDate=DateTime.Parse("2017-05-11"),ExpiryDate=DateTime.Parse("2017-05-12"),QuoteStatus = QuoteStatus.Declined},
            new Quote{CustomerID=2,QuoteDate=DateTime.Parse("2017-05-22"),ExpiryDate=DateTime.Parse("2017-05-23"),QuoteStatus = QuoteStatus.New},
            new Quote{CustomerID=3,QuoteDate=DateTime.Parse("2017-05-30"),ExpiryDate=DateTime.Parse("2017-05-31"),QuoteStatus = QuoteStatus.Accepted},
            new Quote{CustomerID=4,QuoteDate=DateTime.Parse("2017-06-01"),ExpiryDate=DateTime.Parse("2017-06-02"),QuoteStatus = QuoteStatus.New},
            new Quote{CustomerID=4,QuoteDate=DateTime.Parse("2017-06-05"),ExpiryDate=DateTime.Parse("2017-06-06"),QuoteStatus = QuoteStatus.New},
            new Quote{CustomerID=5,QuoteDate=DateTime.Parse("2017-06-06"),ExpiryDate=DateTime.Parse("2017-06-07"),QuoteStatus = QuoteStatus.Accepted},
            new Quote{CustomerID=6,QuoteDate=DateTime.Parse("2017-06-06"),ExpiryDate=DateTime.Parse("2017-06-07"),QuoteStatus = QuoteStatus.New},
            new Quote{CustomerID=7,QuoteDate=DateTime.Parse("2017-05-31"),ExpiryDate=DateTime.Parse("2017-06-01"),QuoteStatus = QuoteStatus.Declined},
            };
            quote.ForEach(q => context.Quotes.Add(q));
            context.SaveChanges();

            var invoiceItem = new List<InvoiceItem>
            {
            new InvoiceItem{InvoiceID=1,ProductID= 1 ,Quantity = 1},
            new InvoiceItem{InvoiceID=2,ProductID= 2 ,Quantity = 2},
            new InvoiceItem{InvoiceID=3,ProductID= 3 ,Quantity = 2},
            new InvoiceItem{InvoiceID=4,ProductID= 3 ,Quantity = 1},
            new InvoiceItem{InvoiceID=5,ProductID= 6 ,Quantity = 4},
            new InvoiceItem{InvoiceID=6,ProductID= 7 ,Quantity = 5},
            new InvoiceItem{InvoiceID=7,ProductID= 10 ,Quantity = 3},
            new InvoiceItem{InvoiceID=8,ProductID= 6 ,Quantity = 7},
            new InvoiceItem{InvoiceID=9,ProductID= 4 ,Quantity = 4},
            new InvoiceItem{InvoiceID=10,ProductID= 4 ,Quantity = 1},
            new InvoiceItem{InvoiceID=11,ProductID= 1 ,Quantity = 1},
            new InvoiceItem{InvoiceID=12,ProductID= 7 ,Quantity = 1},
            };
            invoiceItem.ForEach(i => context.InvoiceItems.Add(i));
            context.SaveChanges();

            var quoteItem = new List<QuoteItem>
            {
            new QuoteItem{QuoteID=1,ProductID= 1 ,Quantity = 1},
            new QuoteItem{QuoteID=2,ProductID= 2 ,Quantity = 2},
            new QuoteItem{QuoteID=3,ProductID= 3 ,Quantity = 2},
            new QuoteItem{QuoteID=4,ProductID= 3 ,Quantity = 1},
            new QuoteItem{QuoteID=5,ProductID= 6 ,Quantity = 4},
            new QuoteItem{QuoteID=6,ProductID= 7 ,Quantity = 5},
            new QuoteItem{QuoteID=7,ProductID= 10 ,Quantity = 3},
            new QuoteItem{QuoteID=8,ProductID= 6 ,Quantity = 7},
            new QuoteItem{QuoteID=9,ProductID= 4 ,Quantity = 4},
            new QuoteItem{QuoteID=10,ProductID= 4 ,Quantity = 1},
            new QuoteItem{QuoteID=11,ProductID= 1 ,Quantity = 1},
            new QuoteItem{QuoteID=12,ProductID= 7 ,Quantity = 1},
            };
            quoteItem.ForEach(q => context.QuoteItems.Add(q));
            context.SaveChanges();

        }
    }
}