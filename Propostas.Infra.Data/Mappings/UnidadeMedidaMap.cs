namespace Propostas.Infra.Data.Mappings
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Propostas.Domain.Models;

    /// <summary>
    ///     Configuração do Entity Framework para a classe <see cref="UnidadeMedida"/>.
    /// </summary>
    public class UnidadeMedidaMap : BaseMap<UnidadeMedida>
    {
        public override void Configure(EntityTypeBuilder<UnidadeMedida> builder)
        {
            base.Configure(builder);

            builder.ToTable("UnidadeMedida");

            builder.Property(c => c.Descricao)
                .HasColumnType("varchar(256)")
                .HasMaxLength(256)
                .IsRequired();

            builder.Property(c => c.Abreviacao)
                .HasColumnType("varchar(16)")
                .HasMaxLength(16);

            builder.HasMany(c => c.Produtos)
                .WithOne(p => p.UnidadeMedida)
                .HasForeignKey(p => p.UnidadeMedidaId);
        }
    }
}
