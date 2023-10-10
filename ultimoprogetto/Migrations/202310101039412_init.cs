namespace ultimoprogetto.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.amministatori",
                c => new
                    {
                        idamministratori = c.Int(nullable: false, identity: true),
                        username = c.String(nullable: false, maxLength: 50),
                        password = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.idamministratori);
            
            CreateTable(
                "dbo.cliente",
                c => new
                    {
                        idcliente = c.Int(nullable: false, identity: true),
                        username = c.String(nullable: false, maxLength: 50),
                        password = c.String(nullable: false, maxLength: 50),
                        nome = c.String(nullable: false, maxLength: 50),
                        cognome = c.String(nullable: false, maxLength: 50),
                        contattotelefonico = c.String(nullable: false, maxLength: 17),
                        email = c.String(nullable: false, maxLength: 120),
                    })
                .PrimaryKey(t => t.idcliente);
            
            CreateTable(
                "dbo.ordini",
                c => new
                    {
                        idordine = c.Int(nullable: false, identity: true),
                        indirizzo = c.String(maxLength: 20),
                        idcliente = c.Int(nullable: false),
                        dataordine = c.DateTime(nullable: false, storeType: "date"),
                    })
                .PrimaryKey(t => t.idordine)
                .ForeignKey("dbo.cliente", t => t.idcliente, cascadeDelete: true)
                .Index(t => t.idcliente);
            
            CreateTable(
                "dbo.pizeeoridnate",
                c => new
                    {
                        idpizeeoridnate = c.Int(nullable: false, identity: true),
                        idordine = c.Int(nullable: false),
                        idpizza = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.idpizeeoridnate)
                .ForeignKey("dbo.ordini", t => t.idordine, cascadeDelete: true)
                .ForeignKey("dbo.pizza", t => t.idpizza, cascadeDelete: true)
                .Index(t => t.idordine)
                .Index(t => t.idpizza);
            
            CreateTable(
                "dbo.pizza",
                c => new
                    {
                        idpizza = c.Int(nullable: false, identity: true),
                        costo = c.Decimal(nullable: false, storeType: "money"),
                        img = c.String(),
                        ingredienti = c.String(nullable: false),
                        nome = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.idpizza);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.pizeeoridnate", "idpizza", "dbo.pizza");
            DropForeignKey("dbo.pizeeoridnate", "idordine", "dbo.ordini");
            DropForeignKey("dbo.ordini", "idcliente", "dbo.cliente");
            DropIndex("dbo.pizeeoridnate", new[] { "idpizza" });
            DropIndex("dbo.pizeeoridnate", new[] { "idordine" });
            DropIndex("dbo.ordini", new[] { "idcliente" });
            DropTable("dbo.pizza");
            DropTable("dbo.pizeeoridnate");
            DropTable("dbo.ordini");
            DropTable("dbo.cliente");
            DropTable("dbo.amministatori");
        }
    }
}
