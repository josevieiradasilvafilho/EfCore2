﻿// <auto-generated />
using System;
using EfCore.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EfCore.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EfCore.Model.Boleto", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CedenteId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ClientId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CompetenciaId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DataEmissao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataVencimento")
                        .HasColumnType("datetime2");

                    b.Property<long>("Numero")
                        .HasColumnType("bigint");

                    b.Property<Guid?>("PessoaId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Sequencial")
                        .IsRequired()
                        .HasColumnType("varchar(10)");

                    b.Property<decimal>("Valor")
                        .HasColumnType("decimal(35, 2)");

                    b.HasKey("Id");

                    b.HasIndex("CedenteId");

                    b.HasIndex("CompetenciaId");

                    b.HasIndex("PessoaId");

                    b.ToTable("Boleto");
                });

            modelBuilder.Entity("EfCore.Model.Cedente", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Agencia")
                        .IsRequired()
                        .HasColumnType("varchar(20)");

                    b.Property<string>("Carteira")
                        .IsRequired()
                        .HasColumnType("varchar(30)");

                    b.Property<string>("Contrato")
                        .IsRequired()
                        .HasColumnType("varchar(20)");

                    b.Property<string>("DigitoVerificador")
                        .IsRequired()
                        .HasColumnType("char(1)");

                    b.Property<string>("Instituicao")
                        .HasColumnType("varchar(200)");

                    b.Property<string>("NomeConta")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.HasKey("Id");

                    b.ToTable("Cedente");
                });

            modelBuilder.Entity("EfCore.Model.Competencia", b =>
                {
                    b.Property<Guid>("CompetenciaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Ano")
                        .HasColumnType("int");

                    b.Property<int>("Mes")
                        .HasColumnType("int");

                    b.HasKey("CompetenciaId");

                    b.ToTable("Competencia");
                });

            modelBuilder.Entity("EfCore.Model.Conta", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("AlterarSenha")
                        .HasColumnType("bit");

                    b.Property<bool>("IsBloqueado")
                        .HasColumnType("bit");

                    b.Property<string>("Login")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("varchar(300)");

                    b.Property<Guid>("PessoaId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasColumnType("varchar(Max)");

                    b.HasKey("Id");

                    b.HasIndex("PessoaId");

                    b.ToTable("Conta");
                });

            modelBuilder.Entity("EfCore.Model.Permissao", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("varchar(300)");

                    b.HasKey("Id");

                    b.ToTable("Permissao");
                });

            modelBuilder.Entity("EfCore.Model.PermissaoConta", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ContaId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Execute")
                        .HasColumnType("bit");

                    b.Property<Guid>("PermissaoId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Read")
                        .HasColumnType("bit");

                    b.Property<bool>("Write")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("ContaId");

                    b.HasIndex("PermissaoId");

                    b.ToTable("PermissaoConta");
                });

            modelBuilder.Entity("EfCore.Model.Pessoa", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Documento")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("varchar(22)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("varchar(300)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(300)");

                    b.Property<string>("Telefone")
                        .HasColumnType("varchar(15)");

                    b.HasKey("Id");

                    b.ToTable("Pessoa");
                });

            modelBuilder.Entity("EfCore.Model.Produto", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Descricao")
                        .HasColumnType("varchar(Max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(300)");

                    b.Property<int>("Quantidade")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Produto");
                });

            modelBuilder.Entity("EfCore.Model.Venda", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Valor")
                        .HasColumnType("decimal(37, 2)");

                    b.HasKey("Id");

                    b.ToTable("Venda");
                });

            modelBuilder.Entity("EfCore.Model.VendaProdutoCompetencia", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CompetenciaId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DataVenda")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("ProdutoId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("QuantidadeVendida")
                        .HasColumnType("int");

                    b.Property<Guid>("VendaId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("CompetenciaId");

                    b.HasIndex("ProdutoId");

                    b.HasIndex("VendaId");

                    b.ToTable("VendaProdutoCompetencias");
                });

            modelBuilder.Entity("EfCore.Model.Boleto", b =>
                {
                    b.HasOne("EfCore.Model.Cedente", "Cedente")
                        .WithMany("Boleto")
                        .HasForeignKey("CedenteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EfCore.Model.Competencia", "Competencia")
                        .WithMany("Boleto")
                        .HasForeignKey("CompetenciaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EfCore.Model.Pessoa", "Pessoa")
                        .WithMany("Boleto")
                        .HasForeignKey("PessoaId");
                });

            modelBuilder.Entity("EfCore.Model.Conta", b =>
                {
                    b.HasOne("EfCore.Model.Pessoa", "Pessoas")
                        .WithMany("Contas")
                        .HasForeignKey("PessoaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EfCore.Model.PermissaoConta", b =>
                {
                    b.HasOne("EfCore.Model.Conta", null)
                        .WithMany("PermissaoConta")
                        .HasForeignKey("ContaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EfCore.Model.Permissao", "Permissao")
                        .WithMany("PermissaoConta")
                        .HasForeignKey("PermissaoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EfCore.Model.VendaProdutoCompetencia", b =>
                {
                    b.HasOne("EfCore.Model.Competencia", "Competencias")
                        .WithMany("VendaProdutoCompetencias")
                        .HasForeignKey("CompetenciaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EfCore.Model.Produto", "Produtos")
                        .WithMany("VendaProdutoCompetencias")
                        .HasForeignKey("ProdutoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EfCore.Model.Venda", "Vendas")
                        .WithMany("VendaProdutoCompetencias")
                        .HasForeignKey("VendaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
