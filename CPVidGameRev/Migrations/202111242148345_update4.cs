namespace CPVidGameRev.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update4 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.GameGenres", "Genre", c => c.String(nullable: false, maxLength: 15));
            AlterColumn("dbo.GameReviews", "GameTitle", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.UserReviews", "UserName", c => c.String(nullable: false, maxLength: 25));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.UserReviews", "UserName", c => c.String());
            AlterColumn("dbo.GameReviews", "GameTitle", c => c.String());
            AlterColumn("dbo.GameGenres", "Genre", c => c.String());
        }
    }
}
