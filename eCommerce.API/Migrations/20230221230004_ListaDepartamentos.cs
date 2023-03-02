using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eCommerce.API.Migrations
{
    /// <inheritdoc />
    public partial class ListaDepartamentos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DepartamentoId",
                table: "UsuarioDepartamentos");

            migrationBuilder.AddColumn<int>(
                name: "UsuarioDepartamentosId",
                table: "Departamentos",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Departamentos_UsuarioDepartamentosId",
                table: "Departamentos",
                column: "UsuarioDepartamentosId");

            migrationBuilder.AddForeignKey(
                name: "FK_Departamentos_UsuarioDepartamentos_UsuarioDepartamentosId",
                table: "Departamentos",
                column: "UsuarioDepartamentosId",
                principalTable: "UsuarioDepartamentos",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Departamentos_UsuarioDepartamentos_UsuarioDepartamentosId",
                table: "Departamentos");

            migrationBuilder.DropIndex(
                name: "IX_Departamentos_UsuarioDepartamentosId",
                table: "Departamentos");

            migrationBuilder.DropColumn(
                name: "UsuarioDepartamentosId",
                table: "Departamentos");

            migrationBuilder.AddColumn<int>(
                name: "DepartamentoId",
                table: "UsuarioDepartamentos",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
