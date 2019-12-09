namespace Propostas.Infra.Data.Mappings
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Propostas.Domain.Models;

    /// <summary>
    ///     Configuração do Entity Framework para a classe <see cref="PerfilUsuario"/>.
    /// </summary>
    public class PerfilUsuarioMap : BaseMap<PerfilUsuario>
    {
        public override void Configure(EntityTypeBuilder<PerfilUsuario> builder)
        {
            base.Configure(builder);

            builder.ToTable("PerfilUsuario");
            
            builder.Property(c => c.Nome)
                .HasColumnType("varchar(256)")
                .HasMaxLength(256)
                .IsRequired();
            
        }
    }
}
