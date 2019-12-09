namespace Propostas.Infra.Data.Seeds
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Propostas.Domain.Models;
    using Propostas.Infra.Data.Context;

    public class PropostaInitializer
    {
        private PropostasContext context;
        private ICollection<Proposta> propostas;

        public PropostaInitializer(PropostasContext context)
        {
            this.context = context;
        }

        public async Task Seed()
        {
            this.propostas = this.Generate();

            /*
            var allPropostas = this.context.Propostas.ToList();
            foreach (var proposta in _propostas)
            {
                if (!allPropostas.Any(c => c.Code == country.Code))
                {
                    this.context.Add(proposta);
                }
            }

            */

            await this.context.SaveChangesAsync();
        }

        private ICollection<Proposta> Generate()
        {
            var proposta = new List<Proposta>();

            /* Insira seus dados na lista */

            return proposta;
        }
    }
}
