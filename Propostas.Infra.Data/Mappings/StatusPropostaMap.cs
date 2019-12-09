namespace Propostas.Infra.Data.Mappings
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Propostas.Domain.Models;

    /// <summary>
    ///     Configuração do Entity Framework para a classe <see cref="StatusProposta"/>.
    /// </summary>
    public class StatusPropostaMap : BaseMap<StatusProposta>
    {
        public override void Configure(EntityTypeBuilder<StatusProposta> builder)
        {
            base.Configure(builder);

            builder.ToTable("StatusProposta");
            
            
            builder.Property(c => c.Nome)
                .HasColumnType("varchar(256)")
                .HasMaxLength(256)
                .IsRequired();
            
        }
    }
}
