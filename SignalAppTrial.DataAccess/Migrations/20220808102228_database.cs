using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SignalAppTrial.DataAccess.Migrations
{
    public partial class database : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Coins",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Symbol = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Market_Cap_Rank = table.Column<int>(type: "int", nullable: false),
                    Current_Price = table.Column<double>(type: "float", nullable: false),
                    Total_Volume = table.Column<double>(type: "float", nullable: false),
                    High_24_Hour = table.Column<double>(type: "float", nullable: false),
                    Low_24_Hour = table.Column<double>(type: "float", nullable: false),
                    Price_Change_24_Hour = table.Column<double>(type: "float", nullable: false),
                    Price_Change_Percentage_24_Hour = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coins", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Coins");
        }
    }
}
