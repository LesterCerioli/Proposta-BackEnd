namespace Propostas.Infra.Data.Mappings
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Propostas.Domain.Models;

    /// <summary>
    ///     Configuração do Entity Framework para a classe <see cref="Cliente"/>.
    /// </summary>
    public class ClienteMap : BaseMap<Cliente>
    {
        public override void Configure(EntityTypeBuilder<Cliente> builder)
        {
            base.Configure(builder);

            builder.ToTable("Cliente");
            
            builder.Property(c => c.CNPJ)
                .HasColumnType("varchar(256)")
                .HasMaxLength(256)
                .IsRequired();

            builder.Property(c => c.RazaoSocial)
                .HasColumnType("varchar(256)")
                .HasMaxLength(256)
                .IsRequired();

            builder.Property(c => c.NomeFantasia)
               .HasColumnType("varchar(256)")
               .HasMaxLength(256)
               .IsRequired();

        }
    }
}
