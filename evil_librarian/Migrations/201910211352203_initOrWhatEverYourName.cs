namespace evil_librarian
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initOrWhatEverYourName : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.book",
                c => new
                    {
                        id_book = c.Int(nullable: false, identity: true),
                        Autor = c.String(nullable: false),
                        Title_of_book = c.String(nullable: false),
                        Date_Of_print = c.DateTime(nullable: false),
                        Quantity = c.Int(),
                        Price = c.Int(),
                    })
                .PrimaryKey(t => t.id_book);
            
            CreateTable(
                "dbo.book_creator",
                c => new
                    {
                        id_book_cr = c.Int(nullable: false),
                        id_creator_cr = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.id_book_cr, t.id_creator_cr })
                .ForeignKey("dbo.book", t => t.id_book_cr, cascadeDelete: true)
                .ForeignKey("dbo.creator", t => t.id_creator_cr, cascadeDelete: true)
                .Index(t => t.id_book_cr)
                .Index(t => t.id_creator_cr);
            
            CreateTable(
                "dbo.creator",
                c => new
                    {
                        id_creator = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        Address = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.id_creator);
            
            CreateTable(
                "dbo.book_genre",
                c => new
                    {
                        id_genre_gn = c.Int(nullable: false),
                        id_book_gn = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.id_genre_gn, t.id_book_gn })
                .ForeignKey("dbo.book", t => t.id_genre_gn, cascadeDelete: true)
                .ForeignKey("dbo.genre", t => t.id_book_gn, cascadeDelete: true)
                .Index(t => t.id_genre_gn)
                .Index(t => t.id_book_gn);
            
            CreateTable(
                "dbo.genre",
                c => new
                    {
                        id_genre = c.Int(nullable: false, identity: true),
                        title_of_genre = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.id_genre);
            
            CreateTable(
                "dbo.Customer",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        First = c.String(),
                        Second = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.extradition",
                c => new
                    {
                        id_book_ex = c.Int(nullable: false, identity: true),
                        id_reader_ex = c.Int(nullable: false),
                        date_extradition = c.DateTime(nullable: false),
                        date_return = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.id_book_ex);
            
            CreateTable(
                "dbo.login",
                c => new
                    {
                        User = c.String(nullable: false, maxLength: 128),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.User);
            
            CreateTable(
                "dbo.People",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.reader",
                c => new
                    {
                        id_reader = c.Int(nullable: false, identity: true),
                        Surname = c.String(nullable: false),
                        name_ = c.String(nullable: false),
                        Patronimic = c.String(),
                        Date_Of_Birth = c.DateTime(nullable: false),
                        Passport = c.String(),
                        Phone = c.String(),
                    })
                .PrimaryKey(t => t.id_reader);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.book_genre", "id_book_gn", "dbo.genre");
            DropForeignKey("dbo.book_genre", "id_genre_gn", "dbo.book");
            DropForeignKey("dbo.book_creator", "id_creator_cr", "dbo.creator");
            DropForeignKey("dbo.book_creator", "id_book_cr", "dbo.book");
            DropIndex("dbo.book_genre", new[] { "id_book_gn" });
            DropIndex("dbo.book_genre", new[] { "id_genre_gn" });
            DropIndex("dbo.book_creator", new[] { "id_creator_cr" });
            DropIndex("dbo.book_creator", new[] { "id_book_cr" });
            DropTable("dbo.reader");
            DropTable("dbo.People");
            DropTable("dbo.login");
            DropTable("dbo.extradition");
            DropTable("dbo.Customer");
            DropTable("dbo.genre");
            DropTable("dbo.book_genre");
            DropTable("dbo.creator");
            DropTable("dbo.book_creator");
            DropTable("dbo.book");
        }
    }
}
