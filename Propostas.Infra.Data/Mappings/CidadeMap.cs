namespace Propostas.Infra.Data.Mappings
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Propostas.Domain.Models;

    /// <summary>
    ///     Configuração do Entity Framework para a classe <see cref="Cidade"/>.
    /// </summary>
    public class CidadeMap : BaseMap<Cidade>
    {
        public override void Configure(EntityTypeBuilder<Cidade> builder)
        {
            base.Configure(builder);

            builder.ToTable("Cidade");

            builder.Property(c => c.Nome)
                .HasColumnType("varchar(255)")
                .HasMaxLength(255)
                .IsRequired();

            builder.Property(c => c.CodigoIbge)
                .IsRequired();

            builder.HasOne(cid => cid.Estado)
                .WithMany(est => est.Cidades)
                .HasForeignKey(cid => cid.EstadoId)
                .IsRequired();
        }
    }
}
