using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class fix_authority_on_delete_behavior_to_cascade : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AUTHORITY_ACCOUNT_Account_NIK",
                table: "AUTHORITY");

            migrationBuilder.DropForeignKey(
                name: "FK_AUTHORITY_ROLE_Role_Id",
                table: "AUTHORITY");

            migrationBuilder.AddForeignKey(
                name: "FK_AUTHORITY_ACCOUNT_Account_NIK",
                table: "AUTHORITY",
                column: "Account_NIK",
                principalTable: "ACCOUNT",
                principalColumn: "NIK",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AUTHORITY_ROLE_Role_Id",
                table: "AUTHORITY",
                column: "Role_Id",
                principalTable: "ROLE",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AUTHORITY_ACCOUNT_Account_NIK",
                table: "AUTHORITY");

            migrationBuilder.DropForeignKey(
                name: "FK_AUTHORITY_ROLE_Role_Id",
                table: "AUTHORITY");

            migrationBuilder.AddForeignKey(
                name: "FK_AUTHORITY_ACCOUNT_Account_NIK",
                table: "AUTHORITY",
                column: "Account_NIK",
                principalTable: "ACCOUNT",
                principalColumn: "NIK");

            migrationBuilder.AddForeignKey(
                name: "FK_AUTHORITY_ROLE_Role_Id",
                table: "AUTHORITY",
                column: "Role_Id",
                principalTable: "ROLE",
                principalColumn: "Id");
        }
    }
}
