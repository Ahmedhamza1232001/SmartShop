using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartShop.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddBrandandType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Brand",
                table: "Mobiles");

            migrationBuilder.DropColumn(
                name: "Brand",
                table: "Computers");

            migrationBuilder.AddColumn<int>(
                name: "ProductBrandId",
                table: "Mobiles",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProductTypeId",
                table: "Mobiles",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProductBrandId",
                table: "Computers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProductTypeId",
                table: "Computers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "ProductBrands",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductBrands", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductTypes", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Mobiles_ProductBrandId",
                table: "Mobiles",
                column: "ProductBrandId");

            migrationBuilder.CreateIndex(
                name: "IX_Mobiles_ProductTypeId",
                table: "Mobiles",
                column: "ProductTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Computers_ProductBrandId",
                table: "Computers",
                column: "ProductBrandId");

            migrationBuilder.CreateIndex(
                name: "IX_Computers_ProductTypeId",
                table: "Computers",
                column: "ProductTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Computers_ProductBrands_ProductBrandId",
                table: "Computers",
                column: "ProductBrandId",
                principalTable: "ProductBrands",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Computers_ProductTypes_ProductTypeId",
                table: "Computers",
                column: "ProductTypeId",
                principalTable: "ProductTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Mobiles_ProductBrands_ProductBrandId",
                table: "Mobiles",
                column: "ProductBrandId",
                principalTable: "ProductBrands",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Mobiles_ProductTypes_ProductTypeId",
                table: "Mobiles",
                column: "ProductTypeId",
                principalTable: "ProductTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Computers_ProductBrands_ProductBrandId",
                table: "Computers");

            migrationBuilder.DropForeignKey(
                name: "FK_Computers_ProductTypes_ProductTypeId",
                table: "Computers");

            migrationBuilder.DropForeignKey(
                name: "FK_Mobiles_ProductBrands_ProductBrandId",
                table: "Mobiles");

            migrationBuilder.DropForeignKey(
                name: "FK_Mobiles_ProductTypes_ProductTypeId",
                table: "Mobiles");

            migrationBuilder.DropTable(
                name: "ProductBrands");

            migrationBuilder.DropTable(
                name: "ProductTypes");

            migrationBuilder.DropIndex(
                name: "IX_Mobiles_ProductBrandId",
                table: "Mobiles");

            migrationBuilder.DropIndex(
                name: "IX_Mobiles_ProductTypeId",
                table: "Mobiles");

            migrationBuilder.DropIndex(
                name: "IX_Computers_ProductBrandId",
                table: "Computers");

            migrationBuilder.DropIndex(
                name: "IX_Computers_ProductTypeId",
                table: "Computers");

            migrationBuilder.DropColumn(
                name: "ProductBrandId",
                table: "Mobiles");

            migrationBuilder.DropColumn(
                name: "ProductTypeId",
                table: "Mobiles");

            migrationBuilder.DropColumn(
                name: "ProductBrandId",
                table: "Computers");

            migrationBuilder.DropColumn(
                name: "ProductTypeId",
                table: "Computers");

            migrationBuilder.AddColumn<string>(
                name: "Brand",
                table: "Mobiles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Brand",
                table: "Computers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
