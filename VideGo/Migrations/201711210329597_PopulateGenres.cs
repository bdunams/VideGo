namespace VideGo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateGenres : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Genres (Id, Name) VALUES (1, 'Comedy')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (2, 'Horror')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (3, 'Action')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (4, 'Animation')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (5, 'Thriller')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (6, 'Adventure')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (7, 'Romance')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (8, 'Western')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (9, 'Science Fiction')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (10, 'Drama')");

        }

        public override void Down()
        {
        }
    }
}
