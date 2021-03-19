using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EfCore.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cedente",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Carteira = table.Column<string>(type: "varchar(30)", nullable: false),
                    Contrato = table.Column<string>(type: "varchar(20)", nullable: false),
                    NomeConta = table.Column<string>(type: "varchar(200)", nullable: false),
                    Agencia = table.Column<string>(type: "varchar(20)", nullable: false),
                    DigitoVerificador = table.Column<string>(type: "char(1)", nullable: false),
                    Instituicao = table.Column<string>(type: "varchar(200)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cedente", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Competencia",
                columns: table => new
                {
                    CompetenciaId = table.Column<Guid>(nullable: false),
                    Ano = table.Column<int>(nullable: false),
                    Mes = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Competencia", x => x.CompetenciaId);
                });

            migrationBuilder.CreateTable(
                name: "Permissao",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Nome = table.Column<string>(type: "varchar(300)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permissao", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pessoa",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Nome = table.Column<string>(type: "varchar(300)", nullable: false),
                    Documento = table.Column<string>(type: "varchar(22)", nullable: false),
                    Email = table.Column<string>(type: "varchar(300)", nullable: false),
                    Telefone = table.Column<string>(type: "varchar(15)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pessoa", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Produto",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Nome = table.Column<string>(type: "varchar(300)", nullable: false),
                    Descricao = table.Column<string>(type: "varchar(Max)", nullable: true),
                    Quantidade = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produto", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Venda",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Valor = table.Column<decimal>(type: "decimal(37, 2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Venda", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Boleto",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Numero = table.Column<long>(type: "bigint", nullable: false),
                    DataVencimento = table.Column<DateTime>(nullable: false),
                    Valor = table.Column<decimal>(type: "decimal(35, 2)", nullable: false),
                    DataEmissao = table.Column<DateTime>(nullable: false),
                    Sequencial = table.Column<string>(type: "varchar(10)", nullable: false),
                    CedenteId = table.Column<Guid>(nullable: false),
                    ClientId = table.Column<Guid>(nullable: false),
                    PessoaId = table.Column<Guid>(nullable: true),
                    CompetenciaId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Boleto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Boleto_Cedente_CedenteId",
                        column: x => x.CedenteId,
                        principalTable: "Cedente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Boleto_Competencia_CompetenciaId",
                        column: x => x.CompetenciaId,
                        principalTable: "Competencia",
                        principalColumn: "CompetenciaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Boleto_Pessoa_PessoaId",
                        column: x => x.PessoaId,
                        principalTable: "Pessoa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Conta",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Login = table.Column<string>(type: "varchar(300)", nullable: false),
                    Senha = table.Column<string>(type: "varchar(Max)", nullable: false),
                    IsBloqueado = table.Column<bool>(nullable: false),
                    AlterarSenha = table.Column<bool>(nullable: false),
                    PessoaId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Conta", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Conta_Pessoa_PessoaId",
                        column: x => x.PessoaId,
                        principalTable: "Pessoa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VendaProdutoCompetencias",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DataVenda = table.Column<DateTime>(nullable: false),
                    QuantidadeVendida = table.Column<int>(nullable: false),
                    VendaId = table.Column<Guid>(nullable: false),
                    ProdutoId = table.Column<Guid>(nullable: false),
                    CompetenciaId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VendaProdutoCompetencias", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VendaProdutoCompetencias_Competencia_CompetenciaId",
                        column: x => x.CompetenciaId,
                        principalTable: "Competencia",
                        principalColumn: "CompetenciaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VendaProdutoCompetencias_Produto_ProdutoId",
                        column: x => x.ProdutoId,
                        principalTable: "Produto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VendaProdutoCompetencias_Venda_VendaId",
                        column: x => x.VendaId,
                        principalTable: "Venda",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PermissaoConta",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ContaId = table.Column<Guid>(nullable: false),
                    Read = table.Column<bool>(nullable: false),
                    Write = table.Column<bool>(nullable: false),
                    Execute = table.Column<bool>(nullable: false),
                    PermissaoId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PermissaoConta", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PermissaoConta_Conta_ContaId",
                        column: x => x.ContaId,
                        principalTable: "Conta",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PermissaoConta_Permissao_PermissaoId",
                        column: x => x.PermissaoId,
                        principalTable: "Permissao",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Boleto_CedenteId",
                table: "Boleto",
                column: "CedenteId");

            migrationBuilder.CreateIndex(
                name: "IX_Boleto_CompetenciaId",
                table: "Boleto",
                column: "CompetenciaId");

            migrationBuilder.CreateIndex(
                name: "IX_Boleto_PessoaId",
                table: "Boleto",
                column: "PessoaId");

            migrationBuilder.CreateIndex(
                name: "IX_Conta_PessoaId",
                table: "Conta",
                column: "PessoaId");

            migrationBuilder.CreateIndex(
                name: "IX_PermissaoConta_ContaId",
                table: "PermissaoConta",
                column: "ContaId");

            migrationBuilder.CreateIndex(
                name: "IX_PermissaoConta_PermissaoId",
                table: "PermissaoConta",
                column: "PermissaoId");

            migrationBuilder.CreateIndex(
                name: "IX_VendaProdutoCompetencias_CompetenciaId",
                table: "VendaProdutoCompetencias",
                column: "CompetenciaId");

            migrationBuilder.CreateIndex(
                name: "IX_VendaProdutoCompetencias_ProdutoId",
                table: "VendaProdutoCompetencias",
                column: "ProdutoId");

            migrationBuilder.CreateIndex(
                name: "IX_VendaProdutoCompetencias_VendaId",
                table: "VendaProdutoCompetencias",
                column: "VendaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Boleto");

            migrationBuilder.DropTable(
                name: "PermissaoConta");

            migrationBuilder.DropTable(
                name: "VendaProdutoCompetencias");

            migrationBuilder.DropTable(
                name: "Cedente");

            migrationBuilder.DropTable(
                name: "Conta");

            migrationBuilder.DropTable(
                name: "Permissao");

            migrationBuilder.DropTable(
                name: "Competencia");

            migrationBuilder.DropTable(
                name: "Produto");

            migrationBuilder.DropTable(
                name: "Venda");

            migrationBuilder.DropTable(
                name: "Pessoa");
        }
    }
}
