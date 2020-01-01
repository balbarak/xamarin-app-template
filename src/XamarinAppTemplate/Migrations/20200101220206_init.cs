using Microsoft.EntityFrameworkCore.Migrations;

namespace XamarinAppTemplate.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CodeTwo = table.Column<string>(nullable: true),
                    Name_Arabic = table.Column<string>(nullable: true),
                    Name_English = table.Column<string>(nullable: true),
                    PhoneCode = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    Capital_Arabic = table.Column<string>(nullable: true),
                    Capital_English = table.Column<string>(nullable: true),
                    Population = table.Column<int>(nullable: true),
                    Latitude = table.Column<float>(nullable: true),
                    Longtitude = table.Column<float>(nullable: true),
                    Area = table.Column<double>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Countries");
        }
    }
}
