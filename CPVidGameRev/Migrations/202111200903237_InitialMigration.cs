namespace CPVidGameRev.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.GameGenres",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Genre = c.String(),
                        TimeAdded = c.DateTime(nullable: false),
                        AverageUserRating = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.GameReviews",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        GameTitle = c.String(),
                        TimeAdded = c.DateTime(nullable: false),
                        ReviewScore = c.Double(nullable: false),
                        ReviewContent = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UserReviews",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        TimeAdded = c.DateTime(nullable: false),
                        ReviewContent = c.String(),
                        UserReviewScore = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.UserReviews");
            DropTable("dbo.GameReviews");
            DropTable("dbo.GameGenres");
        }
    }
}
