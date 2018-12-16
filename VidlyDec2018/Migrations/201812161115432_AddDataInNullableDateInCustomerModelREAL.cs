namespace VidlyDec2018.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDataInNullableDateInCustomerModelREAL : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE Customers SET Birthdate = '1980-01-02' WHERE Id = 1");
        }
        
        public override void Down()
        {
        }
    }
}
