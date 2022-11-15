using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OBM_Project.Migrations
{
    public partial class Nona : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TB_Area",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_Area", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TB_Clientes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(nullable: true),
                    Contato = table.Column<string>(nullable: true),
                    Documento = table.Column<string>(nullable: true),
                    Endereco = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_Clientes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TB_Necessidade",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_Necessidade", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TB_TipoServico",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_TipoServico", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TB_Usuario",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Login = table.Column<string>(nullable: true),
                    Senha = table.Column<string>(nullable: true),
                    Nome = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_Usuario", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TB_Contatos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    Telefone = table.Column<string>(nullable: false),
                    AreaId = table.Column<int>(nullable: false),
                    Assunto = table.Column<string>(nullable: false),
                    Conteudo = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_Contatos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TB_Contatos_TB_Area_AreaId",
                        column: x => x.AreaId,
                        principalTable: "TB_Area",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TB_Demanda",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ClienteId = table.Column<int>(nullable: false),
                    OrcamentoId = table.Column<int>(nullable: false),
                    Valor = table.Column<double>(nullable: false),
                    DataAbertura = table.Column<DateTime>(nullable: false),
                    DataTermino = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_Demanda", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TB_Demanda_TB_Clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "TB_Clientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TB_SubTipoServico",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(nullable: false),
                    TipoServicoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_SubTipoServico", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TB_SubTipoServico_TB_TipoServico_TipoServicoId",
                        column: x => x.TipoServicoId,
                        principalTable: "TB_TipoServico",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TB_Orcamentos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Solicitante = table.Column<string>(nullable: false),
                    SolicitanteContato = table.Column<string>(nullable: false),
                    TipoServicoId = table.Column<int>(nullable: false),
                    SubTipoServicoId = table.Column<int>(nullable: false),
                    NecessidadeId = table.Column<int>(nullable: false),
                    Observacao = table.Column<string>(nullable: false),
                    DataGeracao = table.Column<DateTime>(nullable: false),
                    Valor = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_Orcamentos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TB_Orcamentos_TB_Necessidade_NecessidadeId",
                        column: x => x.NecessidadeId,
                        principalTable: "TB_Necessidade",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TB_Orcamentos_TB_SubTipoServico_SubTipoServicoId",
                        column: x => x.SubTipoServicoId,
                        principalTable: "TB_SubTipoServico",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TB_Orcamentos_TB_TipoServico_TipoServicoId",
                        column: x => x.TipoServicoId,
                        principalTable: "TB_TipoServico",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TB_Contatos_AreaId",
                table: "TB_Contatos",
                column: "AreaId");

            migrationBuilder.CreateIndex(
                name: "IX_TB_Demanda_ClienteId",
                table: "TB_Demanda",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_TB_Orcamentos_NecessidadeId",
                table: "TB_Orcamentos",
                column: "NecessidadeId");

            migrationBuilder.CreateIndex(
                name: "IX_TB_Orcamentos_SubTipoServicoId",
                table: "TB_Orcamentos",
                column: "SubTipoServicoId");

            migrationBuilder.CreateIndex(
                name: "IX_TB_Orcamentos_TipoServicoId",
                table: "TB_Orcamentos",
                column: "TipoServicoId");

            migrationBuilder.CreateIndex(
                name: "IX_TB_SubTipoServico_TipoServicoId",
                table: "TB_SubTipoServico",
                column: "TipoServicoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_Contatos");

            migrationBuilder.DropTable(
                name: "TB_Demanda");

            migrationBuilder.DropTable(
                name: "TB_Orcamentos");

            migrationBuilder.DropTable(
                name: "TB_Usuario");

            migrationBuilder.DropTable(
                name: "TB_Area");

            migrationBuilder.DropTable(
                name: "TB_Clientes");

            migrationBuilder.DropTable(
                name: "TB_Necessidade");

            migrationBuilder.DropTable(
                name: "TB_SubTipoServico");

            migrationBuilder.DropTable(
                name: "TB_TipoServico");
        }
    }
}
