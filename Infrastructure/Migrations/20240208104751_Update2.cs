using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Update2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_AddressTypes_AddressTypeId",
                table: "Addresses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AddressTypes",
                table: "AddressTypes");

            migrationBuilder.RenameTable(
                name: "AddressTypes",
                newName: "AddressType");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AddressType",
                table: "AddressType",
                column: "AddressTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_AddressType_AddressTypeId",
                table: "Addresses",
                column: "AddressTypeId",
                principalTable: "AddressType",
                principalColumn: "AddressTypeId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_AddressType_AddressTypeId",
                table: "Addresses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AddressType",
                table: "AddressType");

            migrationBuilder.RenameTable(
                name: "AddressType",
                newName: "AddressTypes");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AddressTypes",
                table: "AddressTypes",
                column: "AddressTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_AddressTypes_AddressTypeId",
                table: "Addresses",
                column: "AddressTypeId",
                principalTable: "AddressTypes",
                principalColumn: "AddressTypeId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
