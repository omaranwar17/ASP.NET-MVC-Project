using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APP_DATA_A_10.Data.Migrations
{
    /// <inheritdoc />
    public partial class addImagesapp : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "employees",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "employees");
        }
    }
}
