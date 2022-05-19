using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class commit_authority_table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ROLE",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ROLE", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AUTHORITY",
                columns: table => new
                {
                    Account_NIK = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Role_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AUTHORITY", x => new { x.Account_NIK, x.Role_Id });
                    table.ForeignKey(
                        name: "FK_AUTHORITY_ACCOUNT_Account_NIK",
                        column: x => x.Account_NIK,
                        principalTable: "ACCOUNT",
                        principalColumn: "NIK");
                    table.ForeignKey(
                        name: "FK_AUTHORITY_ROLE_Role_Id",
                        column: x => x.Role_Id,
                        principalTable: "ROLE",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AUTHORITY_Role_Id",
                table: "AUTHORITY",
                column: "Role_Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AUTHORITY");

            migrationBuilder.DropTable(
                name: "ROLE");
        }
    }
}
