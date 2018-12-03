namespace FoodFinder.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removeViewModels : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.PriceWatchEntryViewModels", "PriceWatchViewModel_Id", "dbo.PriceWatchViewModels");
            DropIndex("dbo.PriceWatchEntryViewModels", new[] { "PriceWatchViewModel_Id" });
            DropTable("dbo.PriceWatchViewModels");
            DropTable("dbo.PriceWatchEntryViewModels");
            DropTable("dbo.ProductViewModels");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.ProductViewModels",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Tpnb = c.Long(nullable: false),
                        ImageUrl = c.String(),
                        SuperDepartment = c.String(),
                        ContentsMeasureType = c.String(),
                        Name = c.String(),
                        UnitOfSale = c.Int(nullable: false),
                        AverageSellingUnitWeight = c.Decimal(nullable: false, precision: 18, scale: 2),
                        UnitQuantity = c.String(),
                        ContentsQuantity = c.Int(nullable: false),
                        Department = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        UnitPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        HasPriceWatch = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PriceWatchEntryViewModels",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PriceIndicator = c.Int(nullable: false),
                        PriceWatchViewModel_Id = c.Long(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PriceWatchViewModels",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        ImageUrl = c.String(),
                        ProductName = c.String(),
                        ProductDescription = c.String(),
                        CreationDate = c.DateTime(nullable: false),
                        LastUpdate = c.DateTime(),
                        LastPrice = c.Decimal(precision: 18, scale: 2),
                        PriceIndicatorGlyphicon = c.String(),
                        PriceIndicatorBgColor = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.PriceWatchEntryViewModels", "PriceWatchViewModel_Id");
            AddForeignKey("dbo.PriceWatchEntryViewModels", "PriceWatchViewModel_Id", "dbo.PriceWatchViewModels", "Id");
        }
    }
}
