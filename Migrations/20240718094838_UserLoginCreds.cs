using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Downloads.Migrations
{
    /// <inheritdoc />
    public partial class UserLoginCreds : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Credentials",
                columns: table => new
                {
                    PasswordID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PlayerID = table.Column<int>(type: "INTEGER", nullable: false),
                    HashedPassword = table.Column<string>(type: "TEXT", nullable: false),
                    Salty = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Credentials", x => x.PasswordID);
                    table.ForeignKey(
                        name: "FK_Credentials_PlayerStats_PlayerID",
                        column: x => x.PlayerID,
                        principalTable: "PlayerStats",
                        principalColumn: "PlayerID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Credentials_PlayerID",
                table: "Credentials",
                column: "PlayerID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Credentials");
        }
    }
}
