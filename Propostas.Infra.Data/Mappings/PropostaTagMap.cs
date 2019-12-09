namespace Propostas.Infra.Data.Mappings
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Propostas.Domain.Models;

    /// <summary>
    ///     Configuração do Entity Framework para a classe <see cref="PropostaTag"/>.
    /// </summary>
    public class PropostaTagMap : BaseMap<PropostaTag>
    {
        public override void Configure(EntityTypeBuilder<PropostaTag> builder)
        {
            base.Configure(builder);

            builder.ToTable("PropostaTag");

            builder.HasOne(pt => pt.SecaoArquivoTag)
              .WithMany()
              .HasForeignKey(pt => pt.SecaoArquivoTagId)
              .OnDelete(DeleteBehavior.Restrict);

            /*
            builder.Property(c => c.Nome)
                .HasColumnType("varchar(256)")
                .HasMaxLength(256)
                .IsRequired();

            builder.Property(c => c.Codigo)
                .HasColumnType("char(3)")
                .HasMaxLength(3);

            builder.Property(c => c.CodigoBacen)
                .HasColumnType("char(4)")
                .HasMaxLength(4);

            builder.HasMany(pais => pais.Estados)
                .WithOne(est => est.Pais)
                .HasForeignKey(est => est.PaisId);
            */
        }
    }
}
