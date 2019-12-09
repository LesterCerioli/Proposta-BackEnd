namespace Propostas.Infra.Data.Mappings
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Propostas.Domain.Models;

    /// <summary>
    ///     Configuração do Entity Framework para a classe <see cref="Tag"/>.
    /// </summary>
    public class TagMap : BaseMap<Tag>
    {
        public override void Configure(EntityTypeBuilder<Tag> builder)
        {
            base.Configure(builder);

            builder.ToTable("Tag");
            
            builder.HasIndex(tag => new { tag.Chave, tag.Tipo })
                .IsUnique();
        }
    }
}
