namespace Propostas.Infra.Data.Seeds
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Propostas.Domain.Models;
    using Propostas.Infra.Data.Context;

    public class StatusPropostaInitializer
    {
        private PropostasContext context;
        private ICollection<StatusProposta> statuspropostas;

        public StatusPropostaInitializer(PropostasContext context)
        {
            this.context = context;
        }

        public async Task Seed()
        {
            this.statuspropostas = this.Generate();
            var allStatusPropostas = this.context.StatusPropostas.ToList();
            foreach (var statusproposta in this.statuspropostas)
            {
                if (!allStatusPropostas.Any(c => c.Nome == statusproposta.Nome))
                {
                    this.context.Add(statusproposta);
                }
            }

            

            await this.context.SaveChangesAsync();
        }

        private ICollection<StatusProposta> Generate()
        {
            var statusproposta = new List<StatusProposta>();

            statusproposta.Add(new StatusProposta() { Nome = "Aprovado Internamente" });
            statusproposta.Add(new StatusProposta() { Nome = "Enviado para Cliente" });
            statusproposta.Add(new StatusProposta() { Nome = "Lembrete Enviado para Cliente" });
            statusproposta.Add(new StatusProposta() { Nome = "Aprovado" });
            statusproposta.Add(new StatusProposta() { Nome = "Perdido" });
            statusproposta.Add(new StatusProposta() { Nome = "Em Aprovação Interna" });
            
            return statusproposta;
        }
    }
}
