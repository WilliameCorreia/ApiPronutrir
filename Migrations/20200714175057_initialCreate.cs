using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ApiPronutrir.Migrations
{
    public partial class initialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "categorias",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(nullable: true),
                    data = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_categorias", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    login = table.Column<string>(nullable: false),
                    senha = table.Column<string>(nullable: false),
                    nome = table.Column<string>(nullable: false),
                    sobrenome = table.Column<string>(nullable: false),
                    Nacismento = table.Column<DateTime>(nullable: false),
                    ativo = table.Column<bool>(nullable: false),
                    cpf = table.Column<string>(nullable: false),
                    tipoUsuario = table.Column<int>(nullable: false),
                    crm = table.Column<string>(nullable: true),
                    matricula = table.Column<int>(nullable: false),
                    token = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Medicamentos",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(maxLength: 30, nullable: false),
                    quantidade = table.Column<decimal>(nullable: false),
                    Validade = table.Column<DateTime>(nullable: false),
                    categoriaId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medicamentos", x => x.id);
                    table.ForeignKey(
                        name: "FK_Medicamentos_categorias_categoriaId",
                        column: x => x.categoriaId,
                        principalTable: "categorias",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Medicamentos_categoriaId",
                table: "Medicamentos",
                column: "categoriaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Medicamentos");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "categorias");
        }
    }
}
