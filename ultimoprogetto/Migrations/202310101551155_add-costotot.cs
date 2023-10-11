namespace ultimoprogetto.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addcostotot : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ordini", "costotot", c => c.Decimal(nullable: false, storeType: "money"));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ordini", "costotot");
        }
    }
}
