namespace VidlyDec2018.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifyMovieAddNumberAvailable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "NumberAvailable", c => c.Byte(nullable: false));
            Sql("UPDATE Movies SET NumberAvailable = NumberInStock");
        }
        
        public override void Down()
        {
            DropColumn("dbo.Movies", "NumberAvailable");
        }
    }
}
