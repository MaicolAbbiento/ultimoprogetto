namespace ultimoprogetto.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class boolevaso : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ordini", "evaso", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ordini", "evaso");
        }
    }
}
