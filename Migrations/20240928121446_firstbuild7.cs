using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PMSWebApi.Migrations
{
    /// <inheritdoc />
    public partial class firstbuild7 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_KPIs_Employees_EmployeeId",
                table: "KPIs");

            migrationBuilder.DropForeignKey(
                name: "FK_KPIs_Employees_ManagerId",
                table: "KPIs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_KPIs",
                table: "KPIs");

            migrationBuilder.RenameTable(
                name: "KPIs",
                newName: "kPs");

            migrationBuilder.RenameIndex(
                name: "IX_KPIs_ManagerId",
                table: "kPs",
                newName: "IX_kPs_ManagerId");

            migrationBuilder.RenameIndex(
                name: "IX_KPIs_EmployeeId",
                table: "kPs",
                newName: "IX_kPs_EmployeeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_kPs",
                table: "kPs",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_kPs_Employees_EmployeeId",
                table: "kPs",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_kPs_Employees_ManagerId",
                table: "kPs",
                column: "ManagerId",
                principalTable: "Employees",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_kPs_Employees_EmployeeId",
                table: "kPs");

            migrationBuilder.DropForeignKey(
                name: "FK_kPs_Employees_ManagerId",
                table: "kPs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_kPs",
                table: "kPs");

            migrationBuilder.RenameTable(
                name: "kPs",
                newName: "KPIs");

            migrationBuilder.RenameIndex(
                name: "IX_kPs_ManagerId",
                table: "KPIs",
                newName: "IX_KPIs_ManagerId");

            migrationBuilder.RenameIndex(
                name: "IX_kPs_EmployeeId",
                table: "KPIs",
                newName: "IX_KPIs_EmployeeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_KPIs",
                table: "KPIs",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_KPIs_Employees_EmployeeId",
                table: "KPIs",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_KPIs_Employees_ManagerId",
                table: "KPIs",
                column: "ManagerId",
                principalTable: "Employees",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
