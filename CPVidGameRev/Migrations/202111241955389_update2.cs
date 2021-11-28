namespace CPVidGameRev.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.GameGenres", "MaxUserRating", c => c.Double(nullable: false));
            AddColumn("dbo.GameGenres", "MinUserRating", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.GameGenres", "MinUserRating");
            DropColumn("dbo.GameGenres", "MaxUserRating");
        }
    }
}
