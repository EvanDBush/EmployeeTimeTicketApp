using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmployeeTimeTicketApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class ticketparentids : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TimeTickets_Employees_EmployeeId",
                table: "TimeTickets");

            migrationBuilder.DropForeignKey(
                name: "FK_TimeTickets_Projects_ProjectId",
                table: "TimeTickets");

            migrationBuilder.AlterColumn<int>(
                name: "ProjectId",
                table: "TimeTickets",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "EmployeeId",
                table: "TimeTickets",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_TimeTickets_Employees_EmployeeId",
                table: "TimeTickets",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TimeTickets_Projects_ProjectId",
                table: "TimeTickets",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TimeTickets_Employees_EmployeeId",
                table: "TimeTickets");

            migrationBuilder.DropForeignKey(
                name: "FK_TimeTickets_Projects_ProjectId",
                table: "TimeTickets");

            migrationBuilder.AlterColumn<int>(
                name: "ProjectId",
                table: "TimeTickets",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "EmployeeId",
                table: "TimeTickets",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_TimeTickets_Employees_EmployeeId",
                table: "TimeTickets",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TimeTickets_Projects_ProjectId",
                table: "TimeTickets",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id");
        }
    }
}
