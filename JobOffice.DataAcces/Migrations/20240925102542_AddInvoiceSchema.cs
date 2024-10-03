using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobOffice.DataAcces.Migrations
{
    /// <inheritdoc />
    public partial class AddInvoiceSchema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Invoice_Contractors_ContractorId",
                table: "Invoice");

            migrationBuilder.DropForeignKey(
                name: "FK_Invoice_Employees_EmployeeId",
                table: "Invoice");

            migrationBuilder.DropIndex(
                name: "IX_Invoice_ContractorId",
                table: "Invoice");

            migrationBuilder.DropColumn(
                name: "Discount",
                table: "InvoiceItems");

            migrationBuilder.DropColumn(
                name: "ContractorId",
                table: "Invoice");

            migrationBuilder.RenameColumn(
                name: "TotalPrice",
                table: "InvoiceItems",
                newName: "DiscountValue");

            migrationBuilder.RenameColumn(
                name: "IsActive",
                table: "Invoice",
                newName: "IsPaid");

            migrationBuilder.AlterColumn<decimal>(
                name: "Quantity",
                table: "InvoiceItems",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real",
                oldMaxLength: 100);

            migrationBuilder.AddColumn<int>(
                name: "DiscountType",
                table: "InvoiceItems",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "PaymentMethod",
                table: "Invoice",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "EmployeeId",
                table: "Invoice",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "BankAccountDetails",
                table: "Invoice",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CustomerEmail",
                table: "Invoice",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CustomerName",
                table: "Invoice",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "TotalAmount",
                table: "Invoice",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddForeignKey(
                name: "FK_Invoice_Employees_EmployeeId",
                table: "Invoice",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Invoice_Employees_EmployeeId",
                table: "Invoice");

            migrationBuilder.DropColumn(
                name: "DiscountType",
                table: "InvoiceItems");

            migrationBuilder.DropColumn(
                name: "BankAccountDetails",
                table: "Invoice");

            migrationBuilder.DropColumn(
                name: "CustomerEmail",
                table: "Invoice");

            migrationBuilder.DropColumn(
                name: "CustomerName",
                table: "Invoice");

            migrationBuilder.DropColumn(
                name: "TotalAmount",
                table: "Invoice");

            migrationBuilder.RenameColumn(
                name: "DiscountValue",
                table: "InvoiceItems",
                newName: "TotalPrice");

            migrationBuilder.RenameColumn(
                name: "IsPaid",
                table: "Invoice",
                newName: "IsActive");

            migrationBuilder.AlterColumn<float>(
                name: "Quantity",
                table: "InvoiceItems",
                type: "real",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AddColumn<float>(
                name: "Discount",
                table: "InvoiceItems",
                type: "real",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PaymentMethod",
                table: "Invoice",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "EmployeeId",
                table: "Invoice",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ContractorId",
                table: "Invoice",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Invoice_ContractorId",
                table: "Invoice",
                column: "ContractorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Invoice_Contractors_ContractorId",
                table: "Invoice",
                column: "ContractorId",
                principalTable: "Contractors",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Invoice_Employees_EmployeeId",
                table: "Invoice",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
