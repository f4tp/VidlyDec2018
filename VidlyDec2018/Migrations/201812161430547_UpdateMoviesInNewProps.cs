namespace VidlyDec2018.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateMoviesInNewProps : DbMigration
    {
        public override void Up()
        {

            Sql("SET IDENTITY_INSERT Genres ON");
            Sql("INSERT INTO Genres (Id, Name) VALUES (1, 'Action')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (2, 'Thriller')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (3, 'Family')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (4, 'Romance')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (5, 'Comedy')");



            Sql("INSERT INTO Movies (Name, GenreID, ReleaseDate, DateAdded, NumberInStock) VALUES ('He-Man', 3, '1987-07-07', 2018-12-16, 5)");
            Sql("INSERT INTO Movies (Name, GenreID, ReleaseDate, DateAdded, NumberInStock) VALUES ('The Grinch', 3, '2018-11-09', 2018-12-16, 4)");
            Sql("INSERT INTO Movies (Name, GenreID, ReleaseDate, DateAdded, NumberInStock) VALUES ('Terminator 2: Judgement Day', 1, '1991-08-16', 2018-12-16, 3)");
            Sql("INSERT INTO Movies (Name, GenreID, ReleaseDate, DateAdded, NumberInStock) VALUES ('Love Actually', 4, '2003-11-21', 2018-12-16, 2)");

        }

        public override void Down()
        {
        }
    }
}
