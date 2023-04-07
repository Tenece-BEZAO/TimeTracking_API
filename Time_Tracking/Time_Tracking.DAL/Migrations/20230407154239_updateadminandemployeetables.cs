using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Time_Tracking.DAL.Migrations
{
    /// <inheritdoc />
    public partial class updateadminandemployeetables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Admins_AdminId",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_AdminId",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "AdminId",
                table: "Employees");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AdminId",
                table: "Employees",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Employees_AdminId",
                table: "Employees",
                column: "AdminId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Admins_AdminId",
                table: "Employees",
                column: "AdminId",
                principalTable: "Admins",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
