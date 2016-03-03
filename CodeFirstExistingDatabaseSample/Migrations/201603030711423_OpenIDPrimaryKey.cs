namespace CodeFirstExistingDatabaseSample.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OpenIDPrimaryKey : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Oauth2Token", "User_UserID", "dbo.Users");
            DropIndex("dbo.Oauth2Token", new[] { "User_UserID" });
            DropColumn("dbo.Oauth2Token", "WeiXinOpenID");
            RenameColumn(table: "dbo.Oauth2Token", name: "User_UserID", newName: "WeiXinOpenID");
            DropPrimaryKey("dbo.Users");
            AlterColumn("dbo.Oauth2Token", "WeiXinOpenID", c => c.String(maxLength: 128));
            AlterColumn("dbo.Oauth2Token", "WeiXinOpenID", c => c.String(maxLength: 128));
            AlterColumn("dbo.Users", "UserID", c => c.Int(nullable: false));
            AlterColumn("dbo.Users", "WeiXinOpenID", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.Users", "WeiXinOpenID");
            CreateIndex("dbo.Oauth2Token", "WeiXinOpenID");
            CreateIndex("dbo.Users", "UserID", unique: true);
            AddForeignKey("dbo.Oauth2Token", "WeiXinOpenID", "dbo.Users", "WeiXinOpenID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Oauth2Token", "WeiXinOpenID", "dbo.Users");
            DropIndex("dbo.Users", new[] { "UserID" });
            DropIndex("dbo.Oauth2Token", new[] { "WeiXinOpenID" });
            DropPrimaryKey("dbo.Users");
            AlterColumn("dbo.Users", "WeiXinOpenID", c => c.String());
            AlterColumn("dbo.Users", "UserID", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Oauth2Token", "WeiXinOpenID", c => c.Int());
            AlterColumn("dbo.Oauth2Token", "WeiXinOpenID", c => c.String());
            AddPrimaryKey("dbo.Users", "UserID");
            RenameColumn(table: "dbo.Oauth2Token", name: "WeiXinOpenID", newName: "User_UserID");
            AddColumn("dbo.Oauth2Token", "WeiXinOpenID", c => c.String());
            CreateIndex("dbo.Oauth2Token", "User_UserID");
            AddForeignKey("dbo.Oauth2Token", "User_UserID", "dbo.Users", "UserID");
        }
    }
}
