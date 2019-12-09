namespace Propostas.Infra.Data.Mappings
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Propostas.Domain.Models;

    /// <summary>
    ///     Configuração do Entity Framework para a classe <see cref="PublicoAlvo"/>.
    /// </summary>
    public class PublicoAlvoMap : BaseMap<PublicoAlvo>
    {
        public override void Configure(EntityTypeBuilder<PublicoAlvo> builder)
        {
            base.Configure(builder);

            builder.ToTable("PublicoAlvo");
            
            builder.Property(c => c.Nome)
                .HasColumnType("varchar(256)")
                .HasMaxLength(256)
                .IsRequired();
            
        }
    }
}
