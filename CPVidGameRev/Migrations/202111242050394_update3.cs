namespace CPVidGameRev.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.GameReviews", "Reviewer", c => c.String());
            AddColumn("dbo.UserReviews", "NumberOfReviewedGames", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.UserReviews", "NumberOfReviewedGames");
            DropColumn("dbo.GameReviews", "Reviewer");
        }
    }
}
