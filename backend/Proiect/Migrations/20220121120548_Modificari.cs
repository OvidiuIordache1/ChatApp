using Microsoft.EntityFrameworkCore.Migrations;

namespace Proiect.Migrations
{
    public partial class Modificari : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Message_Group_GroupId",
                table: "Message");

            migrationBuilder.DropForeignKey(
                name: "FK_Message_UserInfo_UserInfoId",
                table: "Message");

            migrationBuilder.DropForeignKey(
                name: "FK_MessageDetail_Message_MessageId",
                table: "MessageDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_UserInfo_AspNetUsers_UserId",
                table: "UserInfo");

            migrationBuilder.DropForeignKey(
                name: "FK_UserInfoGroup_Group_GroupId",
                table: "UserInfoGroup");

            migrationBuilder.DropForeignKey(
                name: "FK_UserInfoGroup_UserInfo_UserInfoId",
                table: "UserInfoGroup");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserInfoGroup",
                table: "UserInfoGroup");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserInfo",
                table: "UserInfo");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MessageDetail",
                table: "MessageDetail");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Message",
                table: "Message");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Group",
                table: "Group");

            migrationBuilder.RenameTable(
                name: "UserInfoGroup",
                newName: "UserInfoGroups");

            migrationBuilder.RenameTable(
                name: "UserInfo",
                newName: "UserInfomatii");

            migrationBuilder.RenameTable(
                name: "MessageDetail",
                newName: "MessageDetails");

            migrationBuilder.RenameTable(
                name: "Message",
                newName: "Messages");

            migrationBuilder.RenameTable(
                name: "Group",
                newName: "Groups");

            migrationBuilder.RenameIndex(
                name: "IX_UserInfoGroup_GroupId",
                table: "UserInfoGroups",
                newName: "IX_UserInfoGroups_GroupId");

            migrationBuilder.RenameIndex(
                name: "IX_UserInfo_UserId",
                table: "UserInfomatii",
                newName: "IX_UserInfomatii_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_MessageDetail_MessageId",
                table: "MessageDetails",
                newName: "IX_MessageDetails_MessageId");

            migrationBuilder.RenameIndex(
                name: "IX_Message_UserInfoId",
                table: "Messages",
                newName: "IX_Messages_UserInfoId");

            migrationBuilder.RenameIndex(
                name: "IX_Message_GroupId",
                table: "Messages",
                newName: "IX_Messages_GroupId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserInfoGroups",
                table: "UserInfoGroups",
                columns: new[] { "UserInfoId", "GroupId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserInfomatii",
                table: "UserInfomatii",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MessageDetails",
                table: "MessageDetails",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Messages",
                table: "Messages",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Groups",
                table: "Groups",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MessageDetails_Messages_MessageId",
                table: "MessageDetails",
                column: "MessageId",
                principalTable: "Messages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_Groups_GroupId",
                table: "Messages",
                column: "GroupId",
                principalTable: "Groups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_UserInfomatii_UserInfoId",
                table: "Messages",
                column: "UserInfoId",
                principalTable: "UserInfomatii",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserInfoGroups_Groups_GroupId",
                table: "UserInfoGroups",
                column: "GroupId",
                principalTable: "Groups",
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MessageDetails_Messages_MessageId",
                table: "MessageDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Groups_GroupId",
                table: "Messages");

            migrationBuilder.DropForeignKey(
                name: "FK_Messages_UserInfomatii_UserInfoId",
                table: "Messages");

            migrationBuilder.DropForeignKey(
                name: "FK_UserInfoGroups_Groups_GroupId",
                table: "UserInfoGroups");

            migrationBuilder.DropForeignKey(
                name: "FK_UserInfoGroups_UserInfomatii_UserInfoId",
                table: "UserInfoGroups");

            migrationBuilder.DropForeignKey(
                name: "FK_UserInfomatii_AspNetUsers_UserId",
                table: "UserInfomatii");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserInfomatii",
                table: "UserInfomatii");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserInfoGroups",
                table: "UserInfoGroups");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Messages",
                table: "Messages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MessageDetails",
                table: "MessageDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Groups",
                table: "Groups");

            migrationBuilder.RenameTable(
                name: "UserInfomatii",
                newName: "UserInfo");

            migrationBuilder.RenameTable(
                name: "UserInfoGroups",
                newName: "UserInfoGroup");

            migrationBuilder.RenameTable(
                name: "Messages",
                newName: "Message");

            migrationBuilder.RenameTable(
                name: "MessageDetails",
                newName: "MessageDetail");

            migrationBuilder.RenameTable(
                name: "Groups",
                newName: "Group");

            migrationBuilder.RenameIndex(
                name: "IX_UserInfomatii_UserId",
                table: "UserInfo",
                newName: "IX_UserInfo_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_UserInfoGroups_GroupId",
                table: "UserInfoGroup",
                newName: "IX_UserInfoGroup_GroupId");

            migrationBuilder.RenameIndex(
                name: "IX_Messages_UserInfoId",
                table: "Message",
                newName: "IX_Message_UserInfoId");

            migrationBuilder.RenameIndex(
                name: "IX_Messages_GroupId",
                table: "Message",
                newName: "IX_Message_GroupId");

            migrationBuilder.RenameIndex(
                name: "IX_MessageDetails_MessageId",
                table: "MessageDetail",
                newName: "IX_MessageDetail_MessageId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserInfo",
                table: "UserInfo",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserInfoGroup",
                table: "UserInfoGroup",
                columns: new[] { "UserInfoId", "GroupId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Message",
                table: "Message",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MessageDetail",
                table: "MessageDetail",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Group",
                table: "Group",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Message_Group_GroupId",
                table: "Message",
                column: "GroupId",
                principalTable: "Group",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Message_UserInfo_UserInfoId",
                table: "Message",
                column: "UserInfoId",
                principalTable: "UserInfo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MessageDetail_Message_MessageId",
                table: "MessageDetail",
                column: "MessageId",
                principalTable: "Message",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserInfo_AspNetUsers_UserId",
                table: "UserInfo",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserInfoGroup_Group_GroupId",
                table: "UserInfoGroup",
                column: "GroupId",
                principalTable: "Group",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserInfoGroup_UserInfo_UserInfoId",
                table: "UserInfoGroup",
                column: "UserInfoId",
                principalTable: "UserInfo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
