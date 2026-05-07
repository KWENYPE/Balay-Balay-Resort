using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Balay_Balay_Resort.Migrations
{
    /// <inheritdoc />
    public partial class AddUnitNumberToProperty : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UnitNumber",
                table: "Properties",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UnitNumber",
                table: "Properties");
        }
    }
}
