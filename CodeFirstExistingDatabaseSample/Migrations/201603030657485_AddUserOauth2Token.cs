namespace CodeFirstExistingDatabaseSample.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUserOauth2Token : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Oauth2Token",
                c => new
                    {
                        OTokenID = c.Int(nullable: false, identity: true),
                        WeiXinOpenID = c.String(),
                        AccessToken = c.String(),
                        RefreshToken = c.String(),
                        ExpiresIn = c.Int(nullable: false),
                        Scope = c.String(),
                        User_UserID = c.Int(),
                    })
                .PrimaryKey(t => t.OTokenID)
                .ForeignKey("dbo.Users", t => t.User_UserID)
                .Index(t => t.User_UserID);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        MobileNumber = c.String(),
                        EmailAddress = c.String(),
                        WeiXinOpenID = c.String(),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.UserID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Oauth2Token", "User_UserID", "dbo.Users");
            DropIndex("dbo.Oauth2Token", new[] { "User_UserID" });
            DropTable("dbo.Users");
            DropTable("dbo.Oauth2Token");
        }
    }
}
