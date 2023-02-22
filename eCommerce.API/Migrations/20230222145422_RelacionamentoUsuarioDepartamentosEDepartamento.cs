using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eCommerce.API.Migrations
{
    /// <inheritdoc />
    public partial class RelacionamentoUsuarioDepartamentosEDepartamento : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
        name: "DepartamentoId",
        table: "UsuarioDepartamentos",
        type: "int",
        nullable: false,
        defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioDepartamentos_DepartamentoId",
                table: "UsuarioDepartamentos",
                column: "DepartamentoId");

            migrationBuilder.AddForeignKey(
                name: "FK_UsuarioDepartamentos_Departamentos_DepartamentoId",
                table: "UsuarioDepartamentos",
                column: "DepartamentoId",
                principalTable: "Departamentos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
        name: "FK_UsuarioDepartamentos_Departamentos_DepartamentoId",
        table: "UsuarioDepartamentos");

            migrationBuilder.DropTable(
                name: "Departamentos");

            migrationBuilder.DropIndex(
                name: "IX_UsuarioDepartamentos_DepartamentoId",
                table: "UsuarioDepartamentos");

            migrationBuilder.DropColumn(
                name: "DepartamentoId",
                table: "UsuarioDepartamentos");
        }
    }
}
