namespace Propostas.Infra.Data.Mappings
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Propostas.Domain.Models;

    /// <summary>
    ///     Configuração do Entity Framework para a classe <see cref="Produto"/>.
    /// </summary>
    public class ProdutoMap : BaseMap<Produto>
    {
        public override void Configure(EntityTypeBuilder<Produto> builder)
        {
            base.Configure(builder);

            builder.ToTable("Produto");
            
            builder.Property(c => c.Nome)
                .HasColumnType("varchar(256)")
                .HasMaxLength(256)
                .IsRequired();

            builder.Property(c => c.Descricao)
                .HasColumnType("varchar(256)")
                .HasMaxLength(256);

            builder.Property(c => c.Preco)
                .HasColumnType("money")
                .IsRequired();

            builder.HasOne(c => c.UnidadeMedida)
                .WithMany(um => um.Produtos)
                .HasForeignKey(c => c.UnidadeMedidaId)
                .IsRequired();
        }
    }
}
