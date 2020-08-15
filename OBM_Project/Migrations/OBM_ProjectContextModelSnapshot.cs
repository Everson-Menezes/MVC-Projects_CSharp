﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OBM_Project.Data;

namespace OBM_Project.Migrations
{
    [DbContext(typeof(OBM_ProjectContext))]
    partial class OBM_ProjectContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.14-servicing-32113")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("OBM_Project.Models.Cliente.Clientes", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Contato");

                    b.Property<string>("Documento");

                    b.Property<string>("Endereco");

                    b.Property<string>("Nome");

                    b.HasKey("Id");

                    b.ToTable("TB_Clientes");
                });

            modelBuilder.Entity("OBM_Project.Models.Contato.Area", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Nome");

                    b.HasKey("Id");

                    b.ToTable("TB_Area");
                });

            modelBuilder.Entity("OBM_Project.Models.Contato.Contatos", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AreaId");

                    b.Property<string>("Assunto");

                    b.Property<string>("Conteudo");

                    b.Property<string>("Email");

                    b.Property<string>("Nome");

                    b.Property<string>("Telefone");

                    b.HasKey("Id");

                    b.HasIndex("AreaId");

                    b.ToTable("TB_Contatos");
                });

            modelBuilder.Entity("OBM_Project.Models.Demanda.Demanda", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ClienteId");

                    b.Property<DateTime>("DataAbertura");

                    b.Property<DateTime>("DataTermino");

                    b.Property<int>("OrcamentoId");

                    b.Property<double>("Valor");

                    b.HasKey("Id");

                    b.HasIndex("ClienteId");

                    b.HasIndex("OrcamentoId");

                    b.ToTable("TB_Demanda");
                });

            modelBuilder.Entity("OBM_Project.Models.Orcamento.Necessidade", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Nome");

                    b.HasKey("Id");

                    b.ToTable("TB_Necessidade");
                });

            modelBuilder.Entity("OBM_Project.Models.Orcamento.Orcamentos", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DataGeracao");

                    b.Property<int>("NecessidadeId");

                    b.Property<string>("Observacao");

                    b.Property<int>("SubTipoServicoId");

                    b.Property<int>("TipoServicoId");

                    b.HasKey("Id");

                    b.HasIndex("NecessidadeId");

                    b.HasIndex("SubTipoServicoId");

                    b.HasIndex("TipoServicoId");

                    b.ToTable("TB_Orcamentos");
                });

            modelBuilder.Entity("OBM_Project.Models.Orcamento.SubTipoServico", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Nome");

                    b.Property<int>("TipoServicoId");

                    b.HasKey("Id");

                    b.HasIndex("TipoServicoId");

                    b.ToTable("TB_SubTipoServico");
                });

            modelBuilder.Entity("OBM_Project.Models.Orcamento.TipoServico", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Nome");

                    b.HasKey("Id");

                    b.ToTable("TB_TipoServico");
                });

            modelBuilder.Entity("OBM_Project.Models.Usuario.Usuarios", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Email");

                    b.Property<string>("Login");

                    b.Property<string>("Nome");

                    b.Property<string>("Senha");

                    b.HasKey("Id");

                    b.ToTable("TB_Usuario");
                });

            modelBuilder.Entity("OBM_Project.Models.Contato.Contatos", b =>
                {
                    b.HasOne("OBM_Project.Models.Contato.Area", "Area")
                        .WithMany()
                        .HasForeignKey("AreaId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("OBM_Project.Models.Demanda.Demanda", b =>
                {
                    b.HasOne("OBM_Project.Models.Cliente.Clientes", "Cliente")
                        .WithMany()
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("OBM_Project.Models.Orcamento.Orcamentos", "Orcamento")
                        .WithMany()
                        .HasForeignKey("OrcamentoId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("OBM_Project.Models.Orcamento.Orcamentos", b =>
                {
                    b.HasOne("OBM_Project.Models.Orcamento.Necessidade", "Necesssidade")
                        .WithMany()
                        .HasForeignKey("NecessidadeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("OBM_Project.Models.Orcamento.SubTipoServico", "SubTipoServico")
                        .WithMany()
                        .HasForeignKey("SubTipoServicoId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("OBM_Project.Models.Orcamento.TipoServico", "TipoServico")
                        .WithMany()
                        .HasForeignKey("TipoServicoId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("OBM_Project.Models.Orcamento.SubTipoServico", b =>
                {
                    b.HasOne("OBM_Project.Models.Orcamento.TipoServico", "TipoServico")
                        .WithMany()
                        .HasForeignKey("TipoServicoId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
