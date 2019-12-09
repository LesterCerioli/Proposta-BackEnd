namespace Propostas.Infra.Data.Mappings
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Propostas.Domain.Models;

    public class SecaoArquivoMap : BaseMap<SecaoArquivo>
    {
        public override void Configure(EntityTypeBuilder<SecaoArquivo> builder)
        {
            base.Configure(builder);

            builder.ToTable("SecaoArquivo");

            builder.Property(c => c.Nome)
                  .HasColumnType("varchar(256)")
                  .HasMaxLength(256)
                  .IsRequired();

            builder.Property(c => c.Url)
              .HasColumnType("varchar(256)")
              .HasMaxLength(256)
              .IsRequired();

            builder.Ignore(c => c.Base64Arquivo);
        }
    }
}
