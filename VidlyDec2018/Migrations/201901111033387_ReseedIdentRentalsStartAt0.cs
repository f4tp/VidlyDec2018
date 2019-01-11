namespace VidlyDec2018.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ReseedIdentRentalsStartAt0 : DbMigration
    {
        public override void Up()
        {
            Sql("DBCC CHECKIDENT('[Rentals]', RESEED, 0)");
        }
        
        public override void Down()
        {
        }
    }
}
