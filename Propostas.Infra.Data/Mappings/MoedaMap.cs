namespace Propostas.Infra.Data.Mappings
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Propostas.Domain.Models;

    /// <summary>
    ///     Configuração do Entity Framework para a classe <see cref="Moeda"/>.
    /// </summary>
    public class MoedaMap : BaseMap<Moeda>
    {
        public override void Configure(EntityTypeBuilder<Moeda> builder)
        {
            base.Configure(builder);

            builder.ToTable("Moeda");

            builder.Property(c => c.Nome)
                .HasColumnType("varchar(256)")
                .HasMaxLength(256)
                .IsRequired();

        }
    }
}
