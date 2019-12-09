namespace Propostas.Infra.Data.Seeds
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Propostas.Domain.Models;
    using Propostas.Infra.Data.Context;

    public class TemplateSecaoInitializer
    {
        private PropostasContext context;
        private ICollection<TemplateSecao> templatesecaos;

        public TemplateSecaoInitializer(PropostasContext context)
        {
            this.context = context;
        }

        public async Task Seed()
        {
            this.templatesecaos = this.Generate();

            /*
            var allTemplateSecaos = this.context.TemplateSecaos.ToList();
            foreach (var templatesecao in _templatesecaos)
            {
                if (!allTemplateSecaos.Any(c => c.Code == country.Code))
                {
                    this.context.Add(templatesecao);
                }
            }

            */

            await this.context.SaveChangesAsync();
        }

        private ICollection<TemplateSecao> Generate()
        {
            var templatesecao = new List<TemplateSecao>();

            /* Insira seus dados na lista */

            return templatesecao;
        }
    }
}
