namespace Propostas.Infra.Data.Mappings
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Propostas.Domain.Models;

    /// <summary>
    ///     Configuração do Entity Framework para a classe <see cref="Contato"/>.
    /// </summary>
    public class ContatoMap : BaseMap<Contato>
    {
        public override void Configure(EntityTypeBuilder<Contato> builder)
        {
            base.Configure(builder);

            builder.ToTable("Contato");

            builder.Property(c => c.Nome)
                .HasColumnType("varchar(256)")
                .HasMaxLength(256)
                .IsRequired();

            builder.Property(c => c.Email)
                .HasColumnType("varchar(256)")
                .HasMaxLength(256)
                .IsRequired();

            builder.Property(c => c.Telefone)
                .HasColumnType("varchar(256)")
                .HasMaxLength(256)
                .IsRequired();

            builder.Property(c => c.Celular)
                .HasColumnType("varchar(256)")
                .HasMaxLength(256)
                .IsRequired();

            builder.Property(c => c.Funcao)
                .HasColumnType("varchar(256)")
                .HasMaxLength(256)
                .IsRequired();

            builder.HasOne(contato=> contato.Cliente)
               .WithMany(cliente => cliente.Contatos)
               .HasForeignKey(contato => contato.ClienteId)
               .IsRequired();

            builder.HasOne(contato => contato.TiposContato)
                .WithMany(tc => tc.Contatos)
                .HasForeignKey(contato => contato.TipoContatoId)
                .IsRequired();

        }
    }
}
