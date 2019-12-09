namespace Propostas.Infra.Data.Mappings
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Propostas.Domain.Models;

    /// <summary>
    ///     Configuração do Entity Framework para a classe <see cref="Estado"/>.
    /// </summary>
    public class EstadoMap : BaseMap<Estado>
    {
        public override void Configure(EntityTypeBuilder<Estado> builder)
        {
            base.Configure(builder);

            builder.ToTable("Estado");
            
            builder.Property(c => c.Nome)
                .HasColumnType("varchar(255)")
                .HasMaxLength(255)
                .IsRequired();

            builder.Property(c => c.Uf)
                .HasColumnType("char(2)")
                .HasMaxLength(2)
                .IsRequired();

            builder.Property(c => c.CodigoIbge)
                .IsRequired();

            builder.HasOne(est => est.Pais)
                .WithMany(pais => pais.Estados)
                .HasForeignKey(est => est.PaisId)
                .IsRequired();

            builder.HasMany(est => est.Cidades)
                .WithOne(cid => cid.Estado)
                .HasForeignKey(cid => cid.EstadoId);
        }
    }
}
