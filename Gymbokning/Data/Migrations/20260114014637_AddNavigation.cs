using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gymbokning.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddNavigation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                type: "nvarchar(21)",
                maxLength: 21,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "ApplicationUserGymClass",
                columns: table => new
                {
                    AttendedClassesId = table.Column<int>(type: "int", nullable: false),
                    AttendingMembersId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationUserGymClass", x => new { x.AttendedClassesId, x.AttendingMembersId });
                    table.ForeignKey(
                        name: "FK_ApplicationUserGymClass_AspNetUsers_AttendingMembersId",
                        column: x => x.AttendingMembersId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApplicationUserGymClass_GymClass_AttendedClassesId",
                        column: x => x.AttendedClassesId,
                        principalTable: "GymClass",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationUserGymClass_AttendingMembersId",
                table: "ApplicationUserGymClass",
                column: "AttendingMembersId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApplicationUserGymClass");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");
        }
    }
}
