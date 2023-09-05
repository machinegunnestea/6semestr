using Microsoft.EntityFrameworkCore.Migrations;

namespace СonferenceWeb.Migrations
{
    public partial class lastNo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MemberName",
                table: "Members",
                newName: "PhoneNo");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Members",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Members",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Members",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Topic",
                table: "Members",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Members_ConferenceId",
                table: "Members",
                column: "ConferenceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Members_Conferences_ConferenceId",
                table: "Members",
                column: "ConferenceId",
                principalTable: "Conferences",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Members_Conferences_ConferenceId",
                table: "Members");

            migrationBuilder.DropIndex(
                name: "IX_Members_ConferenceId",
                table: "Members");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Members");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Members");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "Members");

            migrationBuilder.DropColumn(
                name: "Topic",
                table: "Members");

            migrationBuilder.RenameColumn(
                name: "PhoneNo",
                table: "Members",
                newName: "MemberName");
        }
    }
}
