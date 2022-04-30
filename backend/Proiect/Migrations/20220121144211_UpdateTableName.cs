using Microsoft.EntityFrameworkCore.Migrations;

namespace Proiect.Migrations
{
    public partial class UpdateTableName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Messages_UserInfomatii_UserInfoId",
                table: "Messages");

            migrationBuilder.DropForeignKey(
                name: "FK_UserInfoGroups_UserInfomatii_UserInfoId",
                table: "UserInfoGroups");

            migrationBuilder.DropForeignKey(
                name: "FK_UserInfomatii_AspNetUsers_UserId",
                table: "UserInfomatii");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserInfomatii",
                table: "UserInfomatii");

            migrationBuilder.RenameTable(
                name: "UserInfomatii",
                newName: "UserInform");

            migrationBuilder.RenameIndex(
                name: "IX_UserInfomatii_UserId",
                table: "UserInform",
                newName: "IX_UserInform_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserInform",
                table: "UserInform",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_UserInform_UserInfoId",
                table: "Messages",
                column: "UserInfoId",
                principalTable: "UserInform",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserInfoGroups_UserInform_UserInfoId",
                table: "UserInfoGroups",
                column: "UserInfoId",
                principalTable: "UserInform",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserInform_AspNetUsers_UserId",
                table: "UserInform",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Messages_UserInform_UserInfoId",
                table: "Messages");

            migrationBuilder.DropForeignKey(
                name: "FK_UserInfoGroups_UserInform_UserInfoId",
                table: "UserInfoGroups");

            migrationBuilder.DropForeignKey(
                name: "FK_UserInform_AspNetUsers_UserId",
                table: "UserInform");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserInform",
                table: "UserInform");

            migrationBuilder.RenameTable(
                name: "UserInform",
                newName: "UserInfomatii");

            migrationBuilder.RenameIndex(
                name: "IX_UserInform_UserId",
                table: "UserInfomatii",
                newName: "IX_UserInfomatii_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserInfomatii",
                table: "UserInfomatii",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_UserInfomatii_UserInfoId",
                table: "Messages",
                column: "UserInfoId",
                principalTable: "UserInfomatii",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserInfoGroups_UserInfomatii_UserInfoId",
                table: "UserInfoGroups",
                column: "UserInfoId",
                principalTable: "UserInfomatii",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserInfomatii_AspNetUsers_UserId",
                table: "UserInfomatii",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
