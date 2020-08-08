using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OBM_Project.Migrations
{
    public partial class Segunda : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TB_Necessidade",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(nullable: true)
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
                    Nome = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_TipoServico", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TB_SubTipoServico",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(nullable: true),
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
                    TipoServicoId = table.Column<int>(nullable: false),
                    SubTipoServicoId = table.Column<int>(nullable: false),
                    NecessidadeId = table.Column<int>(nullable: false),
                    Observacao = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_Orcamentos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TB_Orcamentos_TB_Necessidade_NecessidadeId",
                        column: x => x.NecessidadeId,
                        principalTable: "tb_necessidade",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TB_Orcamentos_TB_SubTipoServico_SubTipoServicoId",
                        column: x => x.SubTipoServicoId,
                        principalTable: "tb_subtiposervico",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TB_Orcamentos_TB_TipoServico_TipoServicoId",
                        column: x => x.TipoServicoId,
                        principalTable: "tb_tiposervico",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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
                name: "TB_Orcamentos");

            migrationBuilder.DropTable(
                name: "TB_Necessidade");

            migrationBuilder.DropTable(
                name: "TB_SubTipoServico");

            migrationBuilder.DropTable(
                name: "TB_TipoServico");
        }
    }
}
