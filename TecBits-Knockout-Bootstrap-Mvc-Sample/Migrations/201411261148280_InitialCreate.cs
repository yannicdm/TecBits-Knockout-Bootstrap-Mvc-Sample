namespace TecBits_Knockout_Bootstrap_Mvc_Sample.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MTB_Article",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Excerpt = c.String(),
                        Content = c.String(),
                        AuthorId = c.Int(nullable: false),
                        Level = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Authors", t => t.AuthorId, cascadeDelete: true)
                .Index(t => t.AuthorId);
            
            CreateTable(
                "dbo.Authors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MTB_Article", "AuthorId", "dbo.Authors");
            DropIndex("dbo.MTB_Article", new[] { "AuthorId" });
            DropTable("dbo.Authors");
            DropTable("dbo.MTB_Article");
        }
    }
}
