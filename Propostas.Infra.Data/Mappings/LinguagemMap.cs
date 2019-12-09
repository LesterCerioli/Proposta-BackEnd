namespace Propostas.Infra.Data.Mappings
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Propostas.Domain.Models;

    /// <summary>
    ///     Configuração do Entity Framework para a classe <see cref="Linguagem"/>.
    /// </summary>
    public class LinguagemMap : BaseMap<Linguagem>
    {
        public override void Configure(EntityTypeBuilder<Linguagem> builder)
        {
            base.Configure(builder);

            builder.ToTable("Linguagem");
            
            
            builder.Property(c => c.Nome)
                .HasColumnType("varchar(256)")
                .HasMaxLength(256)
                .IsRequired();
            
        }
    }
}
