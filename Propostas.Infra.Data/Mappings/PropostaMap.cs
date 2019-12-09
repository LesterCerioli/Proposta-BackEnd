namespace Propostas.Infra.Data.Mappings
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Propostas.Domain.Models;

    /// <summary>
    ///     Configuração do Entity Framework para a classe <see cref="Proposta"/>.
    /// </summary>
    public class PropostaMap : BaseMap<Proposta>
    {
        public override void Configure(EntityTypeBuilder<Proposta> builder)
        {
            base.Configure(builder);

            builder.ToTable("Proposta");

            builder.HasOne(proposta => proposta.Cliente)
                .WithMany(cliente => cliente.Propostas)
                .HasForeignKey(proposta => proposta.ClienteId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(proposta => proposta.Template)
                .WithMany()
                .HasForeignKey(proposta => proposta.TemplateId)
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
