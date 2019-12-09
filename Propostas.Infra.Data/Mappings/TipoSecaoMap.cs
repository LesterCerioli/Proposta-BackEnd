namespace Propostas.Infra.Data.Mappings
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Propostas.Domain.Models;

    /// <summary>
    ///     Configuração do Entity Framework para a classe <see cref="TipoSecao"/>.
    /// </summary>
    public class TipoSecaoMap : BaseMap<TipoSecao>
    {
        public override void Configure(EntityTypeBuilder<TipoSecao> builder)
        {
            base.Configure(builder);

            builder.ToTable("TipoSecao");

            builder.Property(c => c.Nome)
                .HasColumnType("varchar(256)")
                .HasMaxLength(256)
                .IsRequired();
            
        }
    }
}
