using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eCommerce.API.Migrations
{
    /// <inheritdoc />
    public partial class NovoRelacionamentoModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UsuarioDepartamentos_Departamentos_DepartamentoId",
                table: "UsuarioDepartamentos");

            migrationBuilder.DropForeignKey(
                name: "FK_UsuarioDepartamentos_Usuarios_UsuarioId",
                table: "UsuarioDepartamentos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UsuarioDepartamentos",
                table: "UsuarioDepartamentos");

            migrationBuilder.DropIndex(
                name: "IX_UsuarioDepartamentos_DepartamentoId",
                table: "UsuarioDepartamentos");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "UsuarioDepartamentos");

            migrationBuilder.RenameColumn(
                name: "UsuarioId",
                table: "UsuarioDepartamentos",
                newName: "UsuariosId");

            migrationBuilder.RenameColumn(
                name: "DepartamentoId",
                table: "UsuarioDepartamentos",
                newName: "DepartamentosId");

            migrationBuilder.RenameIndex(
                name: "IX_UsuarioDepartamentos_UsuarioId",
                table: "UsuarioDepartamentos",
                newName: "IX_UsuarioDepartamentos_UsuariosId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UsuarioDepartamentos",
                table: "UsuarioDepartamentos",
                columns: new[] { "DepartamentosId", "UsuariosId" });

            migrationBuilder.AddForeignKey(
                name: "FK_UsuarioDepartamentos_Departamentos_DepartamentosId",
                table: "UsuarioDepartamentos",
                column: "DepartamentosId",
                principalTable: "Departamentos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UsuarioDepartamentos_Usuarios_UsuariosId",
                table: "UsuarioDepartamentos",
                column: "UsuariosId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UsuarioDepartamentos_Departamentos_DepartamentosId",
                table: "UsuarioDepartamentos");

            migrationBuilder.DropForeignKey(
                name: "FK_UsuarioDepartamentos_Usuarios_UsuariosId",
                table: "UsuarioDepartamentos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UsuarioDepartamentos",
                table: "UsuarioDepartamentos");

            migrationBuilder.RenameColumn(
                name: "UsuariosId",
                table: "UsuarioDepartamentos",
                newName: "UsuarioId");

            migrationBuilder.RenameColumn(
                name: "DepartamentosId",
                table: "UsuarioDepartamentos",
                newName: "DepartamentoId");

            migrationBuilder.RenameIndex(
                name: "IX_UsuarioDepartamentos_UsuariosId",
                table: "UsuarioDepartamentos",
                newName: "IX_UsuarioDepartamentos_UsuarioId");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "UsuarioDepartamentos",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UsuarioDepartamentos",
                table: "UsuarioDepartamentos",
                column: "Id");

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

            migrationBuilder.AddForeignKey(
                name: "FK_UsuarioDepartamentos_Usuarios_UsuarioId",
                table: "UsuarioDepartamentos",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
