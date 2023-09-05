using Microsoft.EntityFrameworkCore.Migrations;

namespace СonferenceWeb.Migrations
{
    public partial class MemberName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ConferationId",
                table: "Talks",
                newName: "ConferenceId");

            migrationBuilder.RenameColumn(
                name: "Memberid",
                table: "Members",
                newName: "MemberName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ConferenceId",
                table: "Talks",
                newName: "ConferationId");

            migrationBuilder.RenameColumn(
                name: "MemberName",
                table: "Members",
                newName: "Memberid");
        }
    }
}
