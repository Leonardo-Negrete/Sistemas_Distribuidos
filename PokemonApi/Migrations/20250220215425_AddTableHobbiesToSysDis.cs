using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PokemonApi.Migrations
{
    /// <inheritdoc />
    public partial class AddTableHobbiesToSysDis : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_HobbieEntity",
                table: "HobbieEntity");

            migrationBuilder.RenameTable(
                name: "HobbieEntity",
                newName: "Hobbies");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Hobbies",
                table: "Hobbies",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Hobbies",
                table: "Hobbies");

            migrationBuilder.RenameTable(
                name: "Hobbies",
                newName: "HobbieEntity");

            migrationBuilder.AddPrimaryKey(
                name: "PK_HobbieEntity",
                table: "HobbieEntity",
                column: "Id");
        }
    }
}
