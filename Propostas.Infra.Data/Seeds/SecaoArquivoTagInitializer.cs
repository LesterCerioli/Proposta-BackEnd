namespace Propostas.Infra.Data.Seeds
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Propostas.Domain.Models;
    using Propostas.Infra.Data.Context;

    public class SecaoArquivoTagInitializer
    {
        private PropostasContext context;
        private ICollection<SecaoArquivoTag> secaoarquivotags;

        public SecaoArquivoTagInitializer(PropostasContext context)
        {
            this.context = context;
        }

        public async Task Seed()
        {
            this.secaoarquivotags = this.Generate();

            /*
            var allSecaoArquivoTags = this.context.SecaoArquivoTags.ToList();
            foreach (var secaoarquivotag in _secaoarquivotags)
            {
                if (!allSecaoArquivoTags.Any(c => c.Code == country.Code))
                {
                    this.context.Add(secaoarquivotag);
                }
            }

            */

            await this.context.SaveChangesAsync();
        }

        private ICollection<SecaoArquivoTag> Generate()
        {
            var secaoarquivotag = new List<SecaoArquivoTag>();

            /* Insira seus dados na lista */

            return secaoarquivotag;
        }
    }
}
