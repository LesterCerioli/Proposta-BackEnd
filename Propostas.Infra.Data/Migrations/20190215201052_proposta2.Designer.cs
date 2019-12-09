﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Propostas.Infra.Data.Context;

namespace Propostas.Infra.Data.Migrations
{
    [DbContext(typeof(PropostasContext))]
    [Migration("20190215201052_proposta2")]
    partial class proposta2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Propostas.Domain.Models.Cidade", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Ativo")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Ativo")
                        .HasDefaultValue(true);

                    b.Property<int>("CodigoIbge");

                    b.Property<DateTime>("CriadoEm")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("CriadoEm")
                        .HasDefaultValue(null);

                    b.Property<int>("EstadoId");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(255)")
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.HasIndex("EstadoId");

                    b.ToTable("Cidade");
                });

            modelBuilder.Entity("Propostas.Domain.Models.Cliente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Ativo")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Ativo")
                        .HasDefaultValue(true);

                    b.Property<string>("CNPJ")
                        .IsRequired()
                        .HasColumnType("varchar(256)")
                        .HasMaxLength(256);

                    b.Property<DateTime>("CriadoEm")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("CriadoEm")
                        .HasDefaultValue(null);

                    b.Property<string>("NomeFantasia")
                        .IsRequired()
                        .HasColumnType("varchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("RazaoSocial")
                        .IsRequired()
                        .HasColumnType("varchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.ToTable("Cliente");
                });

            modelBuilder.Entity("Propostas.Domain.Models.Contato", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Ativo")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Ativo")
                        .HasDefaultValue(true);

                    b.Property<string>("Celular")
                        .IsRequired()
                        .HasColumnType("varchar(256)")
                        .HasMaxLength(256);

                    b.Property<int>("ClienteId");

                    b.Property<DateTime>("CriadoEm")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("CriadoEm")
                        .HasDefaultValue(null);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("Funcao")
                        .IsRequired()
                        .HasColumnType("varchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasColumnType("varchar(256)")
                        .HasMaxLength(256);

                    b.Property<int>("TipoContatoId");

                    b.HasKey("Id");

                    b.HasIndex("ClienteId");

                    b.HasIndex("TipoContatoId");

                    b.ToTable("Contato");
                });

            modelBuilder.Entity("Propostas.Domain.Models.Estado", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Ativo")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Ativo")
                        .HasDefaultValue(true);

                    b.Property<int>("CodigoIbge");

                    b.Property<DateTime>("CriadoEm")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("CriadoEm")
                        .HasDefaultValue(null);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(255)")
                        .HasMaxLength(255);

                    b.Property<int>("PaisId");

                    b.Property<string>("Uf")
                        .IsRequired()
                        .HasColumnType("char(2)")
                        .HasMaxLength(2);

                    b.HasKey("Id");

                    b.HasIndex("PaisId");

                    b.ToTable("Estado");
                });

            modelBuilder.Entity("Propostas.Domain.Models.Linguagem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Ativo")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Ativo")
                        .HasDefaultValue(true);

                    b.Property<DateTime>("CriadoEm")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("CriadoEm")
                        .HasDefaultValue(null);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.ToTable("Linguagem");
                });

            modelBuilder.Entity("Propostas.Domain.Models.Moeda", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Ativo")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Ativo")
                        .HasDefaultValue(true);

                    b.Property<DateTime>("CriadoEm")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("CriadoEm")
                        .HasDefaultValue(null);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.ToTable("Moeda");
                });

            modelBuilder.Entity("Propostas.Domain.Models.Pais", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Ativo")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Ativo")
                        .HasDefaultValue(true);

                    b.Property<string>("Codigo")
                        .HasColumnType("char(3)")
                        .HasMaxLength(3);

                    b.Property<string>("CodigoBacen")
                        .HasColumnType("char(4)")
                        .HasMaxLength(4);

                    b.Property<DateTime>("CriadoEm")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("CriadoEm")
                        .HasDefaultValue(null);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.ToTable("Pais");
                });

            modelBuilder.Entity("Propostas.Domain.Models.PerfilUsuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Ativo")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Ativo")
                        .HasDefaultValue(true);

                    b.Property<DateTime>("CriadoEm")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("CriadoEm")
                        .HasDefaultValue(null);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.ToTable("PerfilUsuario");
                });

            modelBuilder.Entity("Propostas.Domain.Models.Produto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Ativo")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Ativo")
                        .HasDefaultValue(true);

                    b.Property<DateTime>("CriadoEm")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("CriadoEm")
                        .HasDefaultValue(null);

                    b.Property<string>("Descricao")
                        .HasColumnType("varchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(256)")
                        .HasMaxLength(256);

                    b.Property<decimal>("Preco")
                        .HasColumnType("money");

                    b.Property<int>("UnidadeMedidaId");

                    b.HasKey("Id");

                    b.HasIndex("UnidadeMedidaId");

                    b.ToTable("Produto");
                });

            modelBuilder.Entity("Propostas.Domain.Models.Proposta", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Ativo")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Ativo")
                        .HasDefaultValue(true);

                    b.Property<int>("ClienteId");

                    b.Property<DateTime>("CriadoEm")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("CriadoEm")
                        .HasDefaultValue(null);

                    b.Property<string>("CustoTotal");

                    b.Property<DateTime>("DataEncerramentoOportunidade");

                    b.Property<DateTime>("DataEnvioPerguntas");

                    b.Property<DateTime>("DataEnvioProposta");

                    b.Property<DateTime>("DataPropostaAlteracao");

                    b.Property<int>("LiderPropostaId");

                    b.Property<int>("LiderSolucaoId");

                    b.Property<int>("MoedaId");

                    b.Property<DateTime>("ObjetivoProposta");

                    b.Property<int>("PrecoTotal");

                    b.Property<int>("TemplateId");

                    b.Property<int>("TempoDuracao");

                    b.Property<string>("Titulo");

                    b.Property<int?>("UsuarioId");

                    b.HasKey("Id");

                    b.HasIndex("ClienteId")
                        .IsUnique();

                    b.HasIndex("LiderPropostaId")
                        .IsUnique();

                    b.HasIndex("LiderSolucaoId")
                        .IsUnique();

                    b.HasIndex("MoedaId")
                        .IsUnique();

                    b.HasIndex("TemplateId")
                        .IsUnique();

                    b.ToTable("Proposta");
                });

            modelBuilder.Entity("Propostas.Domain.Models.PublicoAlvo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Ativo")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Ativo")
                        .HasDefaultValue(true);

                    b.Property<DateTime>("CriadoEm")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("CriadoEm")
                        .HasDefaultValue(null);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.ToTable("PublicoAlvo");
                });

            modelBuilder.Entity("Propostas.Domain.Models.Recurso", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Ativo")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Ativo")
                        .HasDefaultValue(true);

                    b.Property<DateTime>("CriadoEm")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("CriadoEm")
                        .HasDefaultValue(null);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.ToTable("Recurso");
                });

            modelBuilder.Entity("Propostas.Domain.Models.Secao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Ativo")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Ativo")
                        .HasDefaultValue(true);

                    b.Property<DateTime>("CriadoEm")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("CriadoEm")
                        .HasDefaultValue(null);

                    b.Property<DateTime>("DataAlteracao")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("DataAlteracao")
                        .HasDefaultValue(null);

                    b.Property<bool>("Editavel")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Editavel")
                        .HasDefaultValue(true);

                    b.Property<int?>("LinguagemId");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(256)")
                        .HasMaxLength(256);

                    b.Property<int>("Ordem");

                    b.Property<int?>("PublicoAlvoId");

                    b.Property<int?>("TipoSecaoId");

                    b.Property<string>("UsuarioAlteracaoId")
                        .HasConversion(new ValueConverter<string, string>(v => default(string), v => default(string), new ConverterMappingHints(size: 64)))
                        .HasColumnType("varchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("LinguagemId");

                    b.HasIndex("PublicoAlvoId");

                    b.HasIndex("TipoSecaoId");

                    b.ToTable("Secao");
                });

            modelBuilder.Entity("Propostas.Domain.Models.SecaoArquivo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Ativo")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Ativo")
                        .HasDefaultValue(true);

                    b.Property<DateTime>("CriadoEm")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("CriadoEm")
                        .HasDefaultValue(null);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(256)")
                        .HasMaxLength(256);

                    b.Property<DateTime>("Publicado");

                    b.Property<int>("SecaoId");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("varchar(256)")
                        .HasMaxLength(256);

                    b.Property<int?>("UsuarioId");

                    b.HasKey("Id");

                    b.HasIndex("SecaoId");

                    b.ToTable("SecaoArquivo");
                });

            modelBuilder.Entity("Propostas.Domain.Models.StatusProposta", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Ativo")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Ativo")
                        .HasDefaultValue(true);

                    b.Property<DateTime>("CriadoEm")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("CriadoEm")
                        .HasDefaultValue(null);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.ToTable("StatusProposta");
                });

            modelBuilder.Entity("Propostas.Domain.Models.Template", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Ativo")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Ativo")
                        .HasDefaultValue(true);

                    b.Property<DateTime>("CriadoEm")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("CriadoEm")
                        .HasDefaultValue(null);

                    b.Property<string>("Nome");

                    b.Property<int>("TipoTemplateId");

                    b.Property<int>("Versao");

                    b.HasKey("Id");

                    b.HasIndex("TipoTemplateId");

                    b.ToTable("Template");
                });

            modelBuilder.Entity("Propostas.Domain.Models.TemplateSecao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Ativo")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Ativo")
                        .HasDefaultValue(true);

                    b.Property<DateTime>("CriadoEm")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("CriadoEm")
                        .HasDefaultValue(null);

                    b.Property<int>("SecaoId");

                    b.Property<int>("TemplateId");

                    b.HasKey("Id");

                    b.HasIndex("SecaoId");

                    b.HasIndex("TemplateId");

                    b.ToTable("TemplateSecao");
                });

            modelBuilder.Entity("Propostas.Domain.Models.TiposContato", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Ativo")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Ativo")
                        .HasDefaultValue(true);

                    b.Property<DateTime>("CriadoEm")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("CriadoEm")
                        .HasDefaultValue(null);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.ToTable("TiposContato");
                });

            modelBuilder.Entity("Propostas.Domain.Models.TipoSecao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Ativo")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Ativo")
                        .HasDefaultValue(true);

                    b.Property<DateTime>("CriadoEm")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("CriadoEm")
                        .HasDefaultValue(null);

                    b.Property<string>("Formato");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(256)")
                        .HasMaxLength(256);

                    b.Property<bool>("Obrigatorio");

                    b.HasKey("Id");

                    b.ToTable("TipoSecao");
                });

            modelBuilder.Entity("Propostas.Domain.Models.TipoTemplate", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Ativo")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Ativo")
                        .HasDefaultValue(true);

                    b.Property<DateTime>("CriadoEm")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("CriadoEm")
                        .HasDefaultValue(null);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.ToTable("TipoTemplate");
                });

            modelBuilder.Entity("Propostas.Domain.Models.UnidadeMedida", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Abreviacao")
                        .HasColumnType("varchar(16)")
                        .HasMaxLength(16);

                    b.Property<bool>("Ativo")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Ativo")
                        .HasDefaultValue(true);

                    b.Property<DateTime>("CriadoEm")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("CriadoEm")
                        .HasDefaultValue(null);

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("varchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.ToTable("UnidadeMedida");
                });

            modelBuilder.Entity("Propostas.Domain.Models.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Ativo")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Ativo")
                        .HasDefaultValue(true);

                    b.Property<DateTime>("CriadoEm")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("CriadoEm")
                        .HasDefaultValue(null);

                    b.HasKey("Id");

                    b.ToTable("Usuario");
                });

            modelBuilder.Entity("Propostas.Domain.Models.Cidade", b =>
                {
                    b.HasOne("Propostas.Domain.Models.Estado", "Estado")
                        .WithMany("Cidades")
                        .HasForeignKey("EstadoId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Propostas.Domain.Models.Contato", b =>
                {
                    b.HasOne("Propostas.Domain.Models.Cliente", "Cliente")
                        .WithMany("Contatos")
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Propostas.Domain.Models.TiposContato", "TiposContato")
                        .WithMany("Contatos")
                        .HasForeignKey("TipoContatoId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Propostas.Domain.Models.Estado", b =>
                {
                    b.HasOne("Propostas.Domain.Models.Pais", "Pais")
                        .WithMany("Estados")
                        .HasForeignKey("PaisId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Propostas.Domain.Models.Produto", b =>
                {
                    b.HasOne("Propostas.Domain.Models.UnidadeMedida", "UnidadeMedida")
                        .WithMany("Produtos")
                        .HasForeignKey("UnidadeMedidaId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Propostas.Domain.Models.Proposta", b =>
                {
                    b.HasOne("Propostas.Domain.Models.Cliente", "Cliente")
                        .WithOne()
                        .HasForeignKey("Propostas.Domain.Models.Proposta", "ClienteId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Propostas.Domain.Models.Recurso", "LiderProposta")
                        .WithOne("LiderProposta")
                        .HasForeignKey("Propostas.Domain.Models.Proposta", "LiderPropostaId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Propostas.Domain.Models.Recurso", "LiderSolucao")
                        .WithOne("LiderSolucao")
                        .HasForeignKey("Propostas.Domain.Models.Proposta", "LiderSolucaoId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Propostas.Domain.Models.Moeda", "Moeda")
                        .WithOne()
                        .HasForeignKey("Propostas.Domain.Models.Proposta", "MoedaId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Propostas.Domain.Models.Template", "Template")
                        .WithOne()
                        .HasForeignKey("Propostas.Domain.Models.Proposta", "TemplateId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Propostas.Domain.Models.Secao", b =>
                {
                    b.HasOne("Propostas.Domain.Models.Linguagem", "Linguagem")
                        .WithMany("Secoes")
                        .HasForeignKey("LinguagemId");

                    b.HasOne("Propostas.Domain.Models.PublicoAlvo", "PublicoAlvo")
                        .WithMany("Secoes")
                        .HasForeignKey("PublicoAlvoId");

                    b.HasOne("Propostas.Domain.Models.TipoSecao", "TipoSecao")
                        .WithMany("Secoes")
                        .HasForeignKey("TipoSecaoId");
                });

            modelBuilder.Entity("Propostas.Domain.Models.SecaoArquivo", b =>
                {
                    b.HasOne("Propostas.Domain.Models.Secao", "Secao")
                        .WithMany("SecaoArquivo")
                        .HasForeignKey("SecaoId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Propostas.Domain.Models.Template", b =>
                {
                    b.HasOne("Propostas.Domain.Models.TipoTemplate", "TipoTemplate")
                        .WithMany()
                        .HasForeignKey("TipoTemplateId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Propostas.Domain.Models.TemplateSecao", b =>
                {
                    b.HasOne("Propostas.Domain.Models.Secao", "Secao")
                        .WithMany("TemplateSecoes")
                        .HasForeignKey("SecaoId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Propostas.Domain.Models.Template", "Template")
                        .WithMany("TemplateSecoes")
                        .HasForeignKey("TemplateId")
                        .OnDelete(DeleteBehavior.Restrict);
                });
#pragma warning restore 612, 618
        }
    }
}
