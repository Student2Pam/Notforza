using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Downloads.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Car",
                columns: table => new
                {
                    CarID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CarName = table.Column<string>(type: "TEXT", nullable: true),
                    CarModel = table.Column<string>(type: "TEXT", nullable: true),
                    CarYear = table.Column<int>(type: "INTEGER", nullable: false),
                    CarGrade = table.Column<string>(type: "TEXT", nullable: true),
                    CarCost = table.Column<int>(type: "INTEGER", nullable: false),
                    CarDescription = table.Column<string>(type: "TEXT", nullable: true),
                    CarPicURL = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Car", x => x.CarID);
                });

            migrationBuilder.CreateTable(
                name: "PlayerStats",
                columns: table => new
                {
                    PlayerID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Username = table.Column<string>(type: "TEXT", nullable: false),
                    Currency = table.Column<int>(type: "INTEGER", nullable: false),
                    SocialLevel = table.Column<int>(type: "INTEGER", nullable: false),
                    RankLevel = table.Column<int>(type: "INTEGER", nullable: false),
                    XP = table.Column<int>(type: "INTEGER", nullable: false),
                    HouseLocation = table.Column<string>(type: "TEXT", nullable: false),
                    ProfilePic = table.Column<string>(type: "TEXT", nullable: false),
                    Bio = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerStats", x => x.PlayerID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Car");

            migrationBuilder.DropTable(
                name: "PlayerStats");
        }
    }
}
