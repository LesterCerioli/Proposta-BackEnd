namespace Propostas.Infra.Data.Context
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Propostas.Domain.Models;
    using Propostas.Infra.Data.Mappings;
    using System;
    using System.IO;
    using System.Linq;

    public class PropostasContext : DbContext
    {
        // Não remova ou edite a linha abaixo. Utilizado para gerar código automático
        // AddNewDbSet //
        public DbSet<Tag> Tags { get; set; }

        public DbSet<SecaoArquivoTag> SecaoArquivoTags { get; set; }

        public DbSet<PropostaTag> PropostaTags { get; set; }

        public DbSet<Usuario> Usuarios { get; set; }

        public DbSet<Proposta> Propostas { get; set; }

        public DbSet<TemplateSecao> TemplateSecaos { get; set; }

        public DbSet<Template> Templates { get; set; }

        public DbSet<Secao> Secaos { get; set; }


        public DbSet<SecaoArquivo> SecaoArquivos { get; set; }

        public DbSet<StatusProposta> StatusPropostas { get; set; }

        public DbSet<TiposContato> TiposContatos { get; set; }

        public DbSet<PerfilUsuario> PerfilUsuarios { get; set; }

        public DbSet<Contato> Contatos { get; set; }

        public DbSet<Recurso> Recursos { get; set; }

        public DbSet<TipoSecao> TipoSecaos { get; set; }

        public DbSet<Linguagem> Linguagems { get; set; }
        

        public DbSet<TipoTemplate> TipoTemplates { get; set; }

        public DbSet<PublicoAlvo> PublicoAlvos { get; set; }

        public DbSet<Moeda> Moedas { get; set; }

        public DbSet<Cliente> Clientes { get; set; }

        public DbSet<Produto> Produtos { get; set; }
        public DbSet<UnidadeMedida> UnidadeMedidas { get; set; }
        public DbSet<Cidade> Cidades { get; set; }
        public DbSet<Estado> Estados { get; set; }
        public DbSet<Pais> Paises { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Não remova ou edite a linha abaixo. Utilizado para gerar código automático
            // AddNewMapping //
            modelBuilder.ApplyConfiguration(new TagMap());
            modelBuilder.ApplyConfiguration(new SecaoArquivoTagMap());
            modelBuilder.ApplyConfiguration(new PropostaTagMap());
            modelBuilder.ApplyConfiguration(new UsuarioMap());
            modelBuilder.ApplyConfiguration(new PropostaMap());
            modelBuilder.ApplyConfiguration(new TemplateSecaoMap());
            modelBuilder.ApplyConfiguration(new TemplateMap());
            modelBuilder.ApplyConfiguration(new SecaoMap());
            modelBuilder.ApplyConfiguration(new SecaoArquivoMap());
            modelBuilder.ApplyConfiguration(new StatusPropostaMap());
            modelBuilder.ApplyConfiguration(new TiposContatoMap());
            modelBuilder.ApplyConfiguration(new PerfilUsuarioMap());
            modelBuilder.ApplyConfiguration(new ContatoMap());
            modelBuilder.ApplyConfiguration(new RecursoMap());
            modelBuilder.ApplyConfiguration(new TipoSecaoMap());
            modelBuilder.ApplyConfiguration(new LinguagemMap());
            modelBuilder.ApplyConfiguration(new TipoTemplateMap());
            modelBuilder.ApplyConfiguration(new PublicoAlvoMap());
            modelBuilder.ApplyConfiguration(new MoedaMap());
            modelBuilder.ApplyConfiguration(new ClienteMap());
            modelBuilder.ApplyConfiguration(new ProdutoMap());
            modelBuilder.ApplyConfiguration(new UnidadeMedidaMap());
            modelBuilder.ApplyConfiguration(new CidadeMap());
            modelBuilder.ApplyConfiguration(new EstadoMap());
            modelBuilder.ApplyConfiguration(new PaisMap());

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            optionsBuilder.UseSqlServer(config.GetConnectionString("PropostasConnection"));
        }

        public override int SaveChanges()
        {
            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("CriadoEm") != null))
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("CriadoEm").CurrentValue = DateTime.Now;
                }

                if (entry.State == EntityState.Modified)
                {
                    entry.Property("CriadoEm").IsModified = false;
                }
            }
            return base.SaveChanges();
        }
    }
}
