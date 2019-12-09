namespace Propostas.Infra.Data.Mappings
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Propostas.Domain.Models;

    /// <summary>
    ///     Configuração do Entity Framework para a classe <see cref="TiposContato"/>.
    /// </summary>
    public class TiposContatoMap : BaseMap<TiposContato>
    {
        public override void Configure(EntityTypeBuilder<TiposContato> builder)
        {
            base.Configure(builder);

            builder.ToTable("TiposContato");
            
            
            builder.Property(c => c.Nome)
                .HasColumnType("varchar(256)")
                .HasMaxLength(256)
                .IsRequired();

            
        }
    }
}
