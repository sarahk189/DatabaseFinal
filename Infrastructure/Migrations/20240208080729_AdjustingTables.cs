using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AdjustingTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Address_AddressType_AddressTypeId",
                table: "Address");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomersAddress_Address_AddressId",
                table: "CustomersAddress");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomersAddress_Customer_CustomerId",
                table: "CustomersAddress");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomersDetails_Customer_CustomerId",
                table: "CustomersDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CustomersDetails",
                table: "CustomersDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CustomersAddress",
                table: "CustomersAddress");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Customer",
                table: "Customer");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AddressType",
                table: "AddressTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Address",
                table: "Address");

            migrationBuilder.RenameTable(
                name: "CustomersDetails",
                newName: "CustomerDetails");

            migrationBuilder.RenameTable(
                name: "CustomersAddress",
                newName: "CustomerAddresses");

            migrationBuilder.RenameTable(
                name: "Customer",
                newName: "Customers");

            migrationBuilder.RenameTable(
                name: "AddressType",
                newName: "AddressTypes");

            migrationBuilder.RenameTable(
                name: "Address",
                newName: "Addresses");

            migrationBuilder.RenameIndex(
                name: "IX_CustomersAddress_CustomerId",
                table: "CustomerAddresses",
                newName: "IX_CustomerAddresses_CustomerId");

            migrationBuilder.RenameIndex(
                name: "IX_CustomersAddress_AddressId",
                table: "CustomerAddresses",
                newName: "IX_CustomerAddresses_AddressId");

            migrationBuilder.RenameIndex(
                name: "IX_Address_AddressTypeId",
                table: "Addresses",
                newName: "IX_Addresses_AddressTypeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CustomerDetails",
                table: "CustomerDetails",
                column: "CustomerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CustomerAddresses",
                table: "CustomerAddresses",
                column: "CustomerAddressId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Customers",
                table: "Customers",
                column: "CustomerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AddressTypes",
                table: "AddressTypes",
                column: "AddressTypeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Addresses",
                table: "Addresses",
                column: "AddressId");

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_AddressTypes_AddressTypeId",
                table: "Addresses",
                column: "AddressTypeId",
                principalTable: "AddressTypes",
                principalColumn: "AddressTypeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerAddresses_Addresses_AddressId",
                table: "CustomerAddresses",
                column: "AddressId",
                principalTable: "Addresses",
                principalColumn: "AddressId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerAddresses_Customers_CustomerId",
                table: "CustomerAddresses",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "CustomerId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerDetails_Customers_CustomerId",
                table: "CustomerDetails",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "CustomerId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_AddressTypes_AddressTypeId",
                table: "Addresses");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomerAddresses_Addresses_AddressId",
                table: "CustomerAddresses");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomerAddresses_Customers_CustomerId",
                table: "CustomerAddresses");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomerDetails_Customers_CustomerId",
                table: "CustomerDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Customers",
                table: "Customers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CustomerDetails",
                table: "CustomerDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CustomerAddresses",
                table: "CustomerAddresses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AddressTypes",
                table: "AddressTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Addresses",
                table: "Addresses");

            migrationBuilder.RenameTable(
                name: "Customers",
                newName: "Customer");

            migrationBuilder.RenameTable(
                name: "CustomerDetails",
                newName: "CustomersDetails");

            migrationBuilder.RenameTable(
                name: "CustomerAddresses",
                newName: "CustomersAddress");

            migrationBuilder.RenameTable(
                name: "AddressTypes",
                newName: "AddressType");

            migrationBuilder.RenameTable(
                name: "Addresses",
                newName: "Address");

            migrationBuilder.RenameIndex(
                name: "IX_CustomerAddresses_CustomerId",
                table: "CustomersAddress",
                newName: "IX_CustomersAddress_CustomerId");

            migrationBuilder.RenameIndex(
                name: "IX_CustomerAddresses_AddressId",
                table: "CustomersAddress",
                newName: "IX_CustomersAddress_AddressId");

            migrationBuilder.RenameIndex(
                name: "IX_Addresses_AddressTypeId",
                table: "Address",
                newName: "IX_Address_AddressTypeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Customer",
                table: "Customer",
                column: "CustomerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CustomersDetails",
                table: "CustomersDetails",
                column: "CustomerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CustomersAddress",
                table: "CustomersAddress",
                column: "CustomerAddressId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AddressType",
                table: "AddressType",
                column: "AddressTypeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Address",
                table: "Address",
                column: "AddressId");

            migrationBuilder.AddForeignKey(
                name: "FK_Address_AddressType_AddressTypeId",
                table: "Address",
                column: "AddressTypeId",
                principalTable: "AddressType",
                principalColumn: "AddressTypeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CustomersAddress_Address_AddressId",
                table: "CustomersAddress",
                column: "AddressId",
                principalTable: "Address",
                principalColumn: "AddressId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CustomersAddress_Customer_CustomerId",
                table: "CustomersAddress",
                column: "CustomerId",
                principalTable: "Customer",
                principalColumn: "CustomerId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CustomersDetails_Customer_CustomerId",
                table: "CustomersDetails",
                column: "CustomerId",
                principalTable: "Customer",
                principalColumn: "CustomerId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
