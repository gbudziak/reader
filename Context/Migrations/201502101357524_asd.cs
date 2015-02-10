namespace RssDataContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class asd : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Items",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Url = c.String(),
                        Description = c.String(),
                        Title = c.String(),
                        PublishDate = c.DateTime(nullable: false),
                        RatingPlus = c.Int(nullable: false),
                        RatingMinus = c.Int(nullable: false),
                        ChannelId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Channels", t => t.ChannelId, cascadeDelete: true)
                .Index(t => t.ChannelId);
            
            CreateTable(
                "dbo.Channels",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Url = c.String(),
                        Description = c.String(),
                        ImageUrl = c.String(),
                        Title = c.String(),
                        Readers = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UserSubscriptions",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        UserEmail = c.String(),
                        SubscribedUserId = c.String(),
                        ApplicationUserId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUserId)
                .Index(t => t.ApplicationUserId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                        Forname = c.String(),
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
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
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
                "dbo.UserChannels",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Category = c.String(),
                        IsHidden = c.Boolean(nullable: false),
                        ChannelId = c.Long(nullable: false),
                        ApplicationUserId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUserId)
                .ForeignKey("dbo.Channels", t => t.ChannelId, cascadeDelete: true)
                .Index(t => t.ChannelId)
                .Index(t => t.ApplicationUserId);
            
            CreateTable(
                "dbo.UserItems",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Read = c.Boolean(nullable: false),
                        RatingPlus = c.Boolean(nullable: false),
                        RatingMinus = c.Boolean(nullable: false),
                        ItemId = c.Long(nullable: false),
                        ApplicationUserId = c.String(maxLength: 128),
                        UserChannelId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUserId)
                .ForeignKey("dbo.Items", t => t.ItemId, cascadeDelete: true)
                .ForeignKey("dbo.UserChannels", t => t.UserChannelId, cascadeDelete: false)
                .Index(t => t.ItemId)
                .Index(t => t.ApplicationUserId)
                .Index(t => t.UserChannelId);
            
            CreateTable(
                "dbo.UserInfoes",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        PreferredView_Id = c.Long(),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .ForeignKey("dbo.UserCustomViews", t => t.PreferredView_Id)
                .Index(t => t.UserId)
                .Index(t => t.PreferredView_Id);
            
            CreateTable(
                "dbo.UserCustomViews",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        ViewType = c.Int(nullable: false),
                        Image = c.Boolean(nullable: false),
                        Title = c.Boolean(nullable: false),
                        Description = c.Boolean(nullable: false),
                        PublishDate = c.Boolean(nullable: false),
                        Rating = c.Boolean(nullable: false),
                        ItemAge = c.Boolean(nullable: false),
                        UserId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.UsersHistories",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        ActionName = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                        UserChannelId = c.Long(nullable: false),
                        USerItemId = c.Long(nullable: false),
                        SubscriptionId = c.String(),
                        ApplicationUserId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUserId)
                .Index(t => t.ApplicationUserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UsersHistories", "ApplicationUserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.UserInfoes", "PreferredView_Id", "dbo.UserCustomViews");
            DropForeignKey("dbo.UserCustomViews", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.UserInfoes", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.UserItems", "UserChannelId", "dbo.UserChannels");
            DropForeignKey("dbo.UserItems", "ItemId", "dbo.Items");
            DropForeignKey("dbo.UserItems", "ApplicationUserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.UserChannels", "ChannelId", "dbo.Channels");
            DropForeignKey("dbo.UserChannels", "ApplicationUserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.UserSubscriptions", "ApplicationUserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Items", "ChannelId", "dbo.Channels");
            DropIndex("dbo.UsersHistories", new[] { "ApplicationUserId" });
            DropIndex("dbo.UserCustomViews", new[] { "UserId" });
            DropIndex("dbo.UserInfoes", new[] { "PreferredView_Id" });
            DropIndex("dbo.UserInfoes", new[] { "UserId" });
            DropIndex("dbo.UserItems", new[] { "UserChannelId" });
            DropIndex("dbo.UserItems", new[] { "ApplicationUserId" });
            DropIndex("dbo.UserItems", new[] { "ItemId" });
            DropIndex("dbo.UserChannels", new[] { "ApplicationUserId" });
            DropIndex("dbo.UserChannels", new[] { "ChannelId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.UserSubscriptions", new[] { "ApplicationUserId" });
            DropIndex("dbo.Items", new[] { "ChannelId" });
            DropTable("dbo.UsersHistories");
            DropTable("dbo.UserCustomViews");
            DropTable("dbo.UserInfoes");
            DropTable("dbo.UserItems");
            DropTable("dbo.UserChannels");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.UserSubscriptions");
            DropTable("dbo.Channels");
            DropTable("dbo.Items");
        }
    }
}
