using Microsoft.EntityFrameworkCore.Migrations;

namespace CoincidenceApp.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SonDegerler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Sayac = table.Column<long>(type: "INTEGER", nullable: false),
                    GelenDeger = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SonDegerler", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TesadufModels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Sayac = table.Column<long>(type: "INTEGER", nullable: false),
                    GelenDeger = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TesadufModels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Zamanlar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Saniye = table.Column<int>(type: "INTEGER", nullable: false),
                    Dakika = table.Column<int>(type: "INTEGER", nullable: false),
                    Saat = table.Column<int>(type: "INTEGER", nullable: false),
                    Gun = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zamanlar", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SonDegerler");

            migrationBuilder.DropTable(
                name: "TesadufModels");

            migrationBuilder.DropTable(
                name: "Zamanlar");
        }
    }
}
