namespace VidlyDec2018.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ValidationTagsMovieClassErrorMessages : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Movies", "DateAdded", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Movies", "DateAdded", c => c.DateTime(nullable: false));
        }
    }
}
