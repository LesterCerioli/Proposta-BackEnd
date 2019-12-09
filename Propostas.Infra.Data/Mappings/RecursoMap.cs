namespace Propostas.Infra.Data.Mappings
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Propostas.Domain.Models;

    /// <summary>
    ///     Configuração do Entity Framework para a classe <see cref="Recurso"/>.
    /// </summary>
    public class RecursoMap : BaseMap<Recurso>
    {
        public override void Configure(EntityTypeBuilder<Recurso> builder)
        {
            base.Configure(builder);

            builder.ToTable("Recurso");
            
            builder.Property(c => c.Nome)
                .HasColumnType("varchar(256)")
                .HasMaxLength(256)
                .IsRequired();
            
        }
    }
}
