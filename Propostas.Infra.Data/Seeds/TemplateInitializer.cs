namespace Propostas.Infra.Data.Seeds
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Propostas.Domain.Models;
    using Propostas.Infra.Data.Context;

    public class TemplateInitializer
    {
        private PropostasContext context;
        private ICollection<Template> templates;

        public TemplateInitializer(PropostasContext context)
        {
            this.context = context;
        }

        public async Task Seed()
        {
            this.templates = this.Generate();

            /*
            var allTemplates = this.context.Templates.ToList();
            foreach (var template in _templates)
            {
                if (!allTemplates.Any(c => c.Code == country.Code))
                {
                    this.context.Add(template);
                }
            }

            */

            await this.context.SaveChangesAsync();
        }

        private ICollection<Template> Generate()
        {
            var template = new List<Template>();

            /* Insira seus dados na lista */

            return template;
        }
    }
}
