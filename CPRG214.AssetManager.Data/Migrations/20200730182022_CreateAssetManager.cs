using Microsoft.EntityFrameworkCore.Migrations;

namespace CPRG214.AssetManager.Data.Migrations
{
    public partial class CreateAssetManager : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AssetType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssetType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Asset",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TagNumber = table.Column<string>(nullable: false),
                    AssetTypeId = table.Column<int>(nullable: false),
                    Manufacturer = table.Column<string>(nullable: false),
                    Model = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: false),
                    SerialNumber = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Asset", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Asset_AssetType_AssetTypeId",
                        column: x => x.AssetTypeId,
                        principalTable: "AssetType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AssetType",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Computer" });

            migrationBuilder.InsertData(
                table: "AssetType",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "Monitor" });

            migrationBuilder.InsertData(
                table: "AssetType",
                columns: new[] { "Id", "Name" },
                values: new object[] { 3, "Phone" });

            migrationBuilder.InsertData(
                table: "Asset",
                columns: new[] { "Id", "AssetTypeId", "Description", "Manufacturer", "Model", "SerialNumber", "TagNumber" },
                values: new object[,]
                {
                    { 1, 1, "Desktop computer tower", "Dell", "PowerEdge T340", "D12L34", "101" },
                    { 2, 1, "All-in-one desktop computer", "HP", "Pavillion 27\" All-in-One", "H45P67", "102" },
                    { 3, 1, "Laptop computer", "Acer", "Swift 7", "A89C01", "103" },
                    { 4, 2, "Widescreen computer monitor", "Acer", "21.5\" B7 Professional", "A23C45", "201" },
                    { 5, 2, "Ultra-widescreen computer monitor", "LG", "34\" UltraWide QHD", "L67G89", "202" },
                    { 6, 2, "4k computer monitor", "HP", "Envy 27", "H01P23", "203" },
                    { 7, 3, "Multiline deskphone", "Avaya", "T7316E", "A45V67", "301" },
                    { 8, 3, "Multiline deskphone", "Polycom", "VVX 411 IP", "P89C01", "302" },
                    { 9, 3, "Multiline deskphone", "Cisco", "8861 IP", "C23C45", "303" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Asset_AssetTypeId",
                table: "Asset",
                column: "AssetTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Asset");

            migrationBuilder.DropTable(
                name: "AssetType");
        }
    }
}
