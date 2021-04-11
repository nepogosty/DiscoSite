namespace Disco2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class disco : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(),
                        Password = c.String(),
                        Age = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Альбомы",
                c => new
                    {
                        IDальбома = c.Guid(name: "ID альбома", nullable: false),
                        Название = c.String(nullable: false, maxLength: 30, unicode: false),
                        Датавыпуска = c.Int(name: "Дата выпуска", nullable: false),
                        IDтипа = c.Int(name: "ID типа", nullable: false),
                    })
                .PrimaryKey(t => t.IDальбома)
                .ForeignKey("dbo.Тип", t => t.IDтипа)
                .Index(t => t.IDтипа);
            
            CreateTable(
                "dbo.Исполнение композиций",
                c => new
                    {
                        IDисполнениекомпозиции = c.Guid(name: "ID исполнение композиции", nullable: false),
                        Датаисполнения = c.DateTime(name: "Дата исполнения", nullable: false, storeType: "date"),
                        IDмузыканта = c.Guid(name: "ID музыканта"),
                        IDколлектива = c.Guid(name: "ID коллектива"),
                        IDкомпозиции = c.Guid(name: "ID композиции"),
                    })
                .PrimaryKey(t => t.IDисполнениекомпозиции)
                .ForeignKey("dbo.Музыканты в группах", t => new { t.IDмузыканта, t.IDколлектива })
                .ForeignKey("dbo.Композиции", t => t.IDкомпозиции)
                .Index(t => new { t.IDмузыканта, t.IDколлектива })
                .Index(t => t.IDкомпозиции);
            
            CreateTable(
                "dbo.Композиции",
                c => new
                    {
                        IDкомпозиции = c.Guid(nullable: false),
                        Название = c.String(nullable: false, maxLength: 30, unicode: false),
                        Годвыпуска = c.Int(name: "Год выпуска", nullable: false),
                        IDжанра = c.Int(name: "ID жанра", nullable: false),
                    })
                .PrimaryKey(t => t.IDкомпозиции)
                .ForeignKey("dbo.Жанры", t => t.IDжанра)
                .Index(t => t.IDжанра);
            
            CreateTable(
                "dbo.Музыканты",
                c => new
                    {
                        IDмузыканта = c.Guid(nullable: false),
                        Фамилия = c.String(nullable: false, maxLength: 30),
                        Имя = c.String(nullable: false, maxLength: 30, unicode: false),
                        Отчество = c.String(maxLength: 30, unicode: false),
                        Гражданство = c.String(nullable: false, maxLength: 30, unicode: false),
                    })
                .PrimaryKey(t => t.IDмузыканта);
            
            CreateTable(
                "dbo.Музыканты в группах",
                c => new
                    {
                        IDмузыканта = c.Guid(name: "ID музыканта", nullable: false),
                        IDколлектива = c.Guid(name: "ID коллектива", nullable: false),
                        Годвступления = c.Int(name: "Год вступления", nullable: false),
                        Годухода = c.Int(name: "Год ухода"),
                    })
                .PrimaryKey(t => new { t.IDмузыканта, t.IDколлектива })
                .ForeignKey("dbo.Коллективы", t => t.IDколлектива)
                .ForeignKey("dbo.Музыканты", t => t.IDмузыканта)
                .Index(t => t.IDмузыканта)
                .Index(t => t.IDколлектива);
            
            CreateTable(
                "dbo.Коллективы",
                c => new
                    {
                        IDколлектива = c.Guid(name: "ID коллектива", nullable: false),
                        Страна = c.String(nullable: false, maxLength: 30, unicode: false),
                        Название = c.String(nullable: false, maxLength: 50, unicode: false),
                        IDтипаколлектива = c.Int(name: "ID типа коллектива", nullable: false),
                        Годсоздания = c.DateTime(name: "Год создания", nullable: false, storeType: "date"),
                    })
                .PrimaryKey(t => t.IDколлектива)
                .ForeignKey("dbo.Тип коллектива", t => t.IDтипаколлектива)
                .Index(t => t.IDтипаколлектива);
            
            CreateTable(
                "dbo.Тип коллектива",
                c => new
                    {
                        IDтипаколлектива = c.Int(name: "ID типа коллектива", nullable: false),
                        Наименование = c.String(nullable: false, maxLength: 30, unicode: false),
                    })
                .PrimaryKey(t => t.IDтипаколлектива);
            
            CreateTable(
                "dbo.Жанры",
                c => new
                    {
                        IDжанра = c.Int(name: "ID жанра", nullable: false),
                        Название = c.String(nullable: false, maxLength: 30, unicode: false),
                    })
                .PrimaryKey(t => t.IDжанра);
            
            CreateTable(
                "dbo.Тип",
                c => new
                    {
                        IDтипа = c.Int(name: "ID типа", nullable: false),
                        Название = c.String(nullable: false, maxLength: 30, unicode: false),
                    })
                .PrimaryKey(t => t.IDтипа);
            
            CreateTable(
                "dbo.Авторы",
                c => new
                    {
                        IDкомпозиции = c.Guid(nullable: false),
                        IDмузыканта = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.IDкомпозиции, t.IDмузыканта })
                .ForeignKey("dbo.Композиции", t => t.IDкомпозиции, cascadeDelete: true)
                .ForeignKey("dbo.Музыканты", t => t.IDмузыканта, cascadeDelete: true)
                .Index(t => t.IDкомпозиции)
                .Index(t => t.IDмузыканта);
            
            CreateTable(
                "dbo.Композиторы",
                c => new
                    {
                        IDкомпозиции = c.Guid(nullable: false),
                        IDмузыканта = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.IDкомпозиции, t.IDмузыканта })
                .ForeignKey("dbo.Композиции", t => t.IDкомпозиции, cascadeDelete: true)
                .ForeignKey("dbo.Музыканты", t => t.IDмузыканта, cascadeDelete: true)
                .Index(t => t.IDкомпозиции)
                .Index(t => t.IDмузыканта);
            
            CreateTable(
                "dbo.ИК_альбомы",
                c => new
                    {
                        IDальбома = c.Guid(name: "ID альбома", nullable: false),
                        IDисполнениекомпозиции = c.Guid(name: "ID исполнение композиции", nullable: false),
                    })
                .PrimaryKey(t => new { t.IDальбома, t.IDисполнениекомпозиции })
                .ForeignKey("dbo.Альбомы", t => t.IDальбома, cascadeDelete: true)
                .ForeignKey("dbo.Исполнение композиций", t => t.IDисполнениекомпозиции, cascadeDelete: true)
                .Index(t => t.IDальбома)
                .Index(t => t.IDисполнениекомпозиции);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Альбомы", "ID типа", "dbo.Тип");
            DropForeignKey("dbo.ИК_альбомы", "ID исполнение композиции", "dbo.Исполнение композиций");
            DropForeignKey("dbo.ИК_альбомы", "ID альбома", "dbo.Альбомы");
            DropForeignKey("dbo.Композиторы", "IDмузыканта", "dbo.Музыканты");
            DropForeignKey("dbo.Композиторы", "IDкомпозиции", "dbo.Композиции");
            DropForeignKey("dbo.Исполнение композиций", "ID композиции", "dbo.Композиции");
            DropForeignKey("dbo.Композиции", "ID жанра", "dbo.Жанры");
            DropForeignKey("dbo.Авторы", "IDмузыканта", "dbo.Музыканты");
            DropForeignKey("dbo.Авторы", "IDкомпозиции", "dbo.Композиции");
            DropForeignKey("dbo.Музыканты в группах", "ID музыканта", "dbo.Музыканты");
            DropForeignKey("dbo.Коллективы", "ID типа коллектива", "dbo.Тип коллектива");
            DropForeignKey("dbo.Музыканты в группах", "ID коллектива", "dbo.Коллективы");
            DropForeignKey("dbo.Исполнение композиций", new[] { "ID музыканта", "ID коллектива" }, "dbo.Музыканты в группах");
            DropIndex("dbo.ИК_альбомы", new[] { "ID исполнение композиции" });
            DropIndex("dbo.ИК_альбомы", new[] { "ID альбома" });
            DropIndex("dbo.Композиторы", new[] { "IDмузыканта" });
            DropIndex("dbo.Композиторы", new[] { "IDкомпозиции" });
            DropIndex("dbo.Авторы", new[] { "IDмузыканта" });
            DropIndex("dbo.Авторы", new[] { "IDкомпозиции" });
            DropIndex("dbo.Коллективы", new[] { "ID типа коллектива" });
            DropIndex("dbo.Музыканты в группах", new[] { "ID коллектива" });
            DropIndex("dbo.Музыканты в группах", new[] { "ID музыканта" });
            DropIndex("dbo.Композиции", new[] { "ID жанра" });
            DropIndex("dbo.Исполнение композиций", new[] { "ID композиции" });
            DropIndex("dbo.Исполнение композиций", new[] { "ID музыканта", "ID коллектива" });
            DropIndex("dbo.Альбомы", new[] { "ID типа" });
            DropTable("dbo.ИК_альбомы");
            DropTable("dbo.Композиторы");
            DropTable("dbo.Авторы");
            DropTable("dbo.Тип");
            DropTable("dbo.Жанры");
            DropTable("dbo.Тип коллектива");
            DropTable("dbo.Коллективы");
            DropTable("dbo.Музыканты в группах");
            DropTable("dbo.Музыканты");
            DropTable("dbo.Композиции");
            DropTable("dbo.Исполнение композиций");
            DropTable("dbo.Альбомы");
            DropTable("dbo.Users");
        }
    }
}
