namespace ultimoprogetto.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tempo : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.pizza", "tempoConsegnamin", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.pizza", "tempoConsegnamin");
        }
    }
}
