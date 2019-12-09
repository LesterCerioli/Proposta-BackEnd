namespace Propostas.Infra.Data.Seeds
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Propostas.Domain.Models;
    using Propostas.Infra.Data.Context;

    public class SecaoInitializer
    {
        private PropostasContext context;
        private ICollection<Secao> secaos;

        public SecaoInitializer(PropostasContext context)
        {
            this.context = context;
        }

        public async Task Seed()
        {
            this.secaos = this.Generate();

            /*
            var allSecaos = this.context.Secaos.ToList();
            foreach (var secao in _secaos)
            {
                if (!allSecaos.Any(c => c.Code == country.Code))
                {
                    this.context.Add(secao);
                }
            }

            */

            await this.context.SaveChangesAsync();
        }

        private ICollection<Secao> Generate()
        {
            var secao = new List<Secao>();

            /* Insira seus dados na lista */

            return secao;
        }
    }
}
