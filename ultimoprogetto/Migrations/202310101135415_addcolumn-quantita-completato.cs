namespace ultimoprogetto.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addcolumnquantitacompletato : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ordini", "completato", c => c.Boolean(nullable: false));
            AddColumn("dbo.pizeeoridnate", "quantita", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.pizeeoridnate", "quantita");
            DropColumn("dbo.ordini", "completato");
        }
    }
}
