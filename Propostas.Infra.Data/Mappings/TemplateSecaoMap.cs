namespace Propostas.Infra.Data.Mappings
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Propostas.Domain.Models;

    /// <summary>
    ///     Configuração do Entity Framework para a classe <see cref="TemplateSecao"/>.
    /// </summary>
    public class TemplateSecaoMap : BaseMap<TemplateSecao>
    {
        public override void Configure(EntityTypeBuilder<TemplateSecao> builder)
        {
            base.Configure(builder);

            builder.ToTable("TemplateSecao");
            
            builder
                .HasOne<Template>(bc => bc.Template)
                .WithMany(b => b.TemplateSecoes)
                .HasForeignKey(bc => bc.TemplateId)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasOne<Secao>(bc => bc.Secao)
                .WithMany(c => c.TemplateSecoes)
                .HasForeignKey(bc => bc.SecaoId)
                .OnDelete(DeleteBehavior.Cascade);


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