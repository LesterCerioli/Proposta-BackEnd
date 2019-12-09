namespace Propostas.Infra.Data.Mappings
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Propostas.Domain.Models;

    /// <summary>
    ///     Configuração do Entity Framework para a classe <see cref="TipoTemplate"/>.
    /// </summary>
    public class TipoTemplateMap : BaseMap<TipoTemplate>
    {
        public override void Configure(EntityTypeBuilder<TipoTemplate> builder)
        {
            base.Configure(builder);

            builder.ToTable("TipoTemplate");
            
            builder.Property(c => c.Nome)
                .HasColumnType("varchar(256)")
                .HasMaxLength(256)
                .IsRequired();
        }
    }
}
