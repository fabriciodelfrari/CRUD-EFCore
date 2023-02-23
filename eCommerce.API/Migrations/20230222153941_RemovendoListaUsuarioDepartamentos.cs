using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eCommerce.API.Migrations
{
    /// <inheritdoc />
    public partial class RemovendoListaUsuarioDepartamentos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_UsuarioDepartamentos_UsuarioId",
                table: "UsuarioDepartamentos");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioDepartamentos_UsuarioId",
                table: "UsuarioDepartamentos",
                column: "UsuarioId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_UsuarioDepartamentos_UsuarioId",
                table: "UsuarioDepartamentos");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioDepartamentos_UsuarioId",
                table: "UsuarioDepartamentos",
                column: "UsuarioId");
        }
    }
}
