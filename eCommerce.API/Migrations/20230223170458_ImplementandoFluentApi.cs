using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eCommerce.API.Migrations
{
    /// <inheritdoc />
    public partial class ImplementandoFluentApi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            /* Dropados manualmente 
             * migrationBuilder.DropForeignKey(
                 name: "FK_Departamentos_UsuarioDepartamentos_UsuarioDepartamentosId",
                 table: "Departamentos");

             migrationBuilder.DropIndex(
                 name: "IX_Departamentos_UsuarioDepartamentosId",
                 table: "Departamentos");
            
            migrationBuilder.DropColumn(
                name: "UsuarioDepartamentosId",
                table: "Departamentos");
            */
            migrationBuilder.RenameColumn(
                name: "NomeEndereço",
                table: "EnderecosEntrega",
                newName: "NomeEndereco");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataCadastro",
                table: "Usuarios",
                type: "datetime",
                maxLength: 19,
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldMaxLength: 19);

            /*migrationBuilder.AddColumn<int>(
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
                onDelete: ReferentialAction.Cascade);*/
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UsuarioDepartamentos_Departamentos_DepartamentoId",
                table: "UsuarioDepartamentos");

            migrationBuilder.DropIndex(
                name: "IX_UsuarioDepartamentos_DepartamentoId",
                table: "UsuarioDepartamentos");

            migrationBuilder.DropColumn(
                name: "DepartamentoId",
                table: "UsuarioDepartamentos");

            migrationBuilder.RenameColumn(
                name: "NomeEndereco",
                table: "EnderecosEntrega",
                newName: "NomeEndereço");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataCadastro",
                table: "Usuarios",
                type: "datetime2",
                maxLength: 19,
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldMaxLength: 19);

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
    }
}
