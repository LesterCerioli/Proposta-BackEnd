namespace Propostas.Infra.Data.Seeds
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Propostas.Domain.Models;
    using Propostas.Infra.Data.Context;

    public class PropostaTagInitializer
    {
        private PropostasContext context;
        private ICollection<PropostaTag> propostatags;

        public PropostaTagInitializer(PropostasContext context)
        {
            this.context = context;
        }

        public async Task Seed()
        {
            this.propostatags = this.Generate();

            /*
            var allPropostaTags = this.context.PropostaTags.ToList();
            foreach (var propostatag in _propostatags)
            {
                if (!allPropostaTags.Any(c => c.Code == country.Code))
                {
                    this.context.Add(propostatag);
                }
            }

            */

            await this.context.SaveChangesAsync();
        }

        private ICollection<PropostaTag> Generate()
        {
            var propostatag = new List<PropostaTag>();

            /* Insira seus dados na lista */

            return propostatag;
        }
    }
}
