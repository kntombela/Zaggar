namespace Zaggar.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customer",
                c => new
                    {
                        CustomerID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 50),
                        LastName = c.String(nullable: false, maxLength: 50),
                        Street = c.String(nullable: false),
                        Suburb = c.String(),
                        City = c.String(nullable: false),
                        Country = c.String(nullable: false, maxLength: 50),
                        PostalCode = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.CustomerID);
            
            CreateTable(
                "dbo.Invoice",
                c => new
                    {
                        InvoiceID = c.Int(nullable: false, identity: true),
                        InvoiceDate = c.DateTime(nullable: false),
                        CustomerID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.InvoiceID)
                .ForeignKey("dbo.Customer", t => t.CustomerID, cascadeDelete: true)
                .Index(t => t.CustomerID);
            
            CreateTable(
                "dbo.InvoiceItem",
                c => new
                    {
                        Item = c.Int(nullable: false, identity: true),
                        Quantity = c.Int(nullable: false),
                        InvoiceID = c.Int(nullable: false),
                        ProductID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Item)
                .ForeignKey("dbo.Invoice", t => t.InvoiceID, cascadeDelete: true)
                .ForeignKey("dbo.Product", t => t.ProductID, cascadeDelete: true)
                .Index(t => t.InvoiceID)
                .Index(t => t.ProductID);
            
            CreateTable(
                "dbo.Product",
                c => new
                    {
                        ProductID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Price = c.Double(nullable: false),
                        VAT = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.ProductID);
            
            CreateTable(
                "dbo.Quote",
                c => new
                    {
                        QuoteID = c.Int(nullable: false, identity: true),
                        QuoteDate = c.DateTime(nullable: false),
                        ExpiryDate = c.DateTime(nullable: false),
                        QuoteStatus = c.Int(),
                        Discount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CustomerID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.QuoteID)
                .ForeignKey("dbo.Customer", t => t.CustomerID, cascadeDelete: true)
                .Index(t => t.CustomerID);
            
            CreateTable(
                "dbo.QuoteItem",
                c => new
                    {
                        Item = c.Int(nullable: false, identity: true),
                        Quantity = c.Int(nullable: false),
                        QuoteID = c.Int(nullable: false),
                        ProductID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Item)
                .ForeignKey("dbo.Product", t => t.ProductID, cascadeDelete: true)
                .ForeignKey("dbo.Quote", t => t.QuoteID, cascadeDelete: true)
                .Index(t => t.QuoteID)
                .Index(t => t.ProductID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.QuoteItem", "QuoteID", "dbo.Quote");
            DropForeignKey("dbo.QuoteItem", "ProductID", "dbo.Product");
            DropForeignKey("dbo.Quote", "CustomerID", "dbo.Customer");
            DropForeignKey("dbo.InvoiceItem", "ProductID", "dbo.Product");
            DropForeignKey("dbo.InvoiceItem", "InvoiceID", "dbo.Invoice");
            DropForeignKey("dbo.Invoice", "CustomerID", "dbo.Customer");
            DropIndex("dbo.QuoteItem", new[] { "ProductID" });
            DropIndex("dbo.QuoteItem", new[] { "QuoteID" });
            DropIndex("dbo.Quote", new[] { "CustomerID" });
            DropIndex("dbo.InvoiceItem", new[] { "ProductID" });
            DropIndex("dbo.InvoiceItem", new[] { "InvoiceID" });
            DropIndex("dbo.Invoice", new[] { "CustomerID" });
            DropTable("dbo.QuoteItem");
            DropTable("dbo.Quote");
            DropTable("dbo.Product");
            DropTable("dbo.InvoiceItem");
            DropTable("dbo.Invoice");
            DropTable("dbo.Customer");
        }
    }
}
