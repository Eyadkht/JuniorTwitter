namespace Bootstrap3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addingDataBase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Conversation_Type",
                c => new
                    {
                        Conversation_TypeID = c.Int(nullable: false, identity: true),
                        Text = c.String(),
                    })
                .PrimaryKey(t => t.Conversation_TypeID);
            
            CreateTable(
                "dbo.Streams",
                c => new
                    {
                        StreamID = c.Int(nullable: false, identity: true),
                        CompanyID = c.String(maxLength: 128),
                        Name = c.String(),
                        Language = c.String(),
                        Location = c.String(),
                        Conversation_TypeID = c.Int(),
                        Target_IndustryID = c.Int(),
                    })
                .PrimaryKey(t => t.StreamID)
                .ForeignKey("dbo.Conversation_Type", t => t.Conversation_TypeID)
                .ForeignKey("dbo.Target_Industry", t => t.Target_IndustryID)
                .ForeignKey("dbo.AspNetUsers", t => t.CompanyID)
                .Index(t => t.CompanyID)
                .Index(t => t.Conversation_TypeID)
                .Index(t => t.Target_IndustryID);
            
            CreateTable(
                "dbo.Target_Industry",
                c => new
                    {
                        Target_IndustryID = c.Int(nullable: false, identity: true),
                        text = c.String(),
                    })
                .PrimaryKey(t => t.Target_IndustryID);
            
            CreateTable(
                "dbo.IndustryWords",
                c => new
                    {
                        IndustryWordID = c.Int(nullable: false, identity: true),
                        Text = c.String(),
                        Target_IndustryID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IndustryWordID)
                .ForeignKey("dbo.Target_Industry", t => t.Target_IndustryID, cascadeDelete: true)
                .Index(t => t.Target_IndustryID);
            
            CreateTable(
                "dbo.Stream_Keyword",
                c => new
                    {
                        Stream_KeywordID = c.Int(nullable: false, identity: true),
                        StreamID = c.Int(nullable: false),
                        IndustryWordID = c.Int(),
                    })
                .PrimaryKey(t => t.Stream_KeywordID)
                .ForeignKey("dbo.IndustryWords", t => t.IndustryWordID)
                .ForeignKey("dbo.Streams", t => t.StreamID, cascadeDelete: true)
                .Index(t => t.StreamID)
                .Index(t => t.IndustryWordID);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        CustomerID = c.Int(nullable: false, identity: true),
                        CompanyID = c.String(maxLength: 128),
                        Name = c.String(),
                        DateOfBirth = c.DateTime(),
                        Gender = c.String(),
                        Email = c.String(),
                        PhoneNumber = c.String(),
                        Screen_Name = c.Binary(),
                        Full_Name = c.String(),
                        Description = c.String(),
                        Language = c.String(),
                        Location = c.String(),
                        Number_Of_Tweets = c.Int(),
                        Total_Following = c.Int(),
                        Total_Followers = c.Int(),
                    })
                .PrimaryKey(t => t.CustomerID)
                .ForeignKey("dbo.AspNetUsers", t => t.CompanyID)
                .Index(t => t.CompanyID);
            
            CreateTable(
                "dbo.Messages",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        CustomerID = c.Int(nullable: false),
                        CompanyID = c.String(maxLength: 128),
                        Text = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Customers", t => t.CustomerID, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.CompanyID)
                .Index(t => t.CustomerID)
                .Index(t => t.CompanyID);
            
            CreateTable(
                "dbo.Tweets",
                c => new
                    {
                        TweetID = c.Int(nullable: false, identity: true),
                        CustomerID = c.Int(nullable: false),
                        Text = c.String(),
                        in_reply_To_Tweet_ID = c.Int(),
                        Lang = c.String(),
                        Location = c.String(),
                        Retweet_Count = c.Int(),
                        Is_Retweeted = c.Boolean(),
                        CreatedAt = c.DateTime(),
                        CreatedBy = c.String(),
                    })
                .PrimaryKey(t => t.TweetID)
                .ForeignKey("dbo.Customers", t => t.CustomerID, cascadeDelete: true)
                .Index(t => t.CustomerID);
            
            CreateTable(
                "dbo.Hashtags",
                c => new
                    {
                        HashtagID = c.Int(nullable: false, identity: true),
                        TweetID = c.Int(nullable: false),
                        Text = c.String(),
                    })
                .PrimaryKey(t => t.HashtagID)
                .ForeignKey("dbo.Tweets", t => t.TweetID, cascadeDelete: true)
                .Index(t => t.TweetID);
            
            CreateTable(
                "dbo.URL_Tweet",
                c => new
                    {
                        URL_TweetID = c.Int(nullable: false, identity: true),
                        TweetID = c.Int(nullable: false),
                        URL = c.String(),
                    })
                .PrimaryKey(t => t.URL_TweetID)
                .ForeignKey("dbo.Tweets", t => t.TweetID, cascadeDelete: true)
                .Index(t => t.TweetID);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Screen_Name = c.String(),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Streams", "CompanyID", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Messages", "CompanyID", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Customers", "CompanyID", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.URL_Tweet", "TweetID", "dbo.Tweets");
            DropForeignKey("dbo.Hashtags", "TweetID", "dbo.Tweets");
            DropForeignKey("dbo.Tweets", "CustomerID", "dbo.Customers");
            DropForeignKey("dbo.Messages", "CustomerID", "dbo.Customers");
            DropForeignKey("dbo.Streams", "Target_IndustryID", "dbo.Target_Industry");
            DropForeignKey("dbo.IndustryWords", "Target_IndustryID", "dbo.Target_Industry");
            DropForeignKey("dbo.Stream_Keyword", "StreamID", "dbo.Streams");
            DropForeignKey("dbo.Stream_Keyword", "IndustryWordID", "dbo.IndustryWords");
            DropForeignKey("dbo.Streams", "Conversation_TypeID", "dbo.Conversation_Type");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.URL_Tweet", new[] { "TweetID" });
            DropIndex("dbo.Hashtags", new[] { "TweetID" });
            DropIndex("dbo.Tweets", new[] { "CustomerID" });
            DropIndex("dbo.Messages", new[] { "CompanyID" });
            DropIndex("dbo.Messages", new[] { "CustomerID" });
            DropIndex("dbo.Customers", new[] { "CompanyID" });
            DropIndex("dbo.Stream_Keyword", new[] { "IndustryWordID" });
            DropIndex("dbo.Stream_Keyword", new[] { "StreamID" });
            DropIndex("dbo.IndustryWords", new[] { "Target_IndustryID" });
            DropIndex("dbo.Streams", new[] { "Target_IndustryID" });
            DropIndex("dbo.Streams", new[] { "Conversation_TypeID" });
            DropIndex("dbo.Streams", new[] { "CompanyID" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.URL_Tweet");
            DropTable("dbo.Hashtags");
            DropTable("dbo.Tweets");
            DropTable("dbo.Messages");
            DropTable("dbo.Customers");
            DropTable("dbo.Stream_Keyword");
            DropTable("dbo.IndustryWords");
            DropTable("dbo.Target_Industry");
            DropTable("dbo.Streams");
            DropTable("dbo.Conversation_Type");
        }
    }
}
