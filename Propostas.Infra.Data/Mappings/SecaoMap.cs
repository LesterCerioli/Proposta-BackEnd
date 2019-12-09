namespace Propostas.Infra.Data.Mappings
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Propostas.Domain.Models;

    /// <summary>
    ///     Configuração do Entity Framework para a classe <see cref="Secao"/>.
    /// </summary>
    public class SecaoMap : BaseMap<Secao>
    {
        public override void Configure(EntityTypeBuilder<Secao> builder)
        {
            base.Configure(builder);

            builder.ToTable("Secao");
            
            
            builder.Property(c => c.Nome)
                .HasColumnType("varchar(256)")
                .HasMaxLength(256)
                .IsRequired();

            builder.Property(c => c.Editavel)
            .HasColumnName("Editavel")
            .HasDefaultValue(true);

            builder.HasOne(secao => secao.Linguagem)
               .WithMany(linguagem => linguagem.Secoes)
               .HasForeignKey(secao => secao.LinguagemId);

            builder.HasOne(secao => secao.TipoSecao)
               .WithMany(ts => ts.Secoes)
               .HasForeignKey(secao => secao.TipoSecaoId);

            builder.HasOne(secao => secao.PublicoAlvo)
               .WithMany(pub => pub.Secoes)
               .HasForeignKey(secao => secao.PublicoAlvoId);
            
            builder.Property(c => c.Ordem)
                .IsRequired();

            builder.Property(c => c.DataAlteracao)
                 .HasColumnName("DataAlteracao")
                 .HasDefaultValue();

            builder.Property(c => c.UsuarioAlteracaoId)
              .HasColumnType("varchar(256)")
              .HasMaxLength(256);
        }
    }
}
