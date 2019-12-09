namespace Propostas.Infra.Data.Seeds
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Propostas.Domain.Models;
    using Propostas.Infra.Data.Context;

    public class ContatoInitializer
    {
        private PropostasContext context;
        private ICollection<Contato> contatos;

        public ContatoInitializer(PropostasContext context)
        {
            this.context = context;
        }

        public async Task Seed()
        {
            this.contatos = this.Generate();

            /*
            var allContatos = this.context.Contatos.ToList();
            foreach (var contato in _contatos)
            {
                if (!allContatos.Any(c => c.Code == country.Code))
                {
                    this.context.Add(contato);
                }
            }

            */

            await this.context.SaveChangesAsync();
        }

        private ICollection<Contato> Generate()
        {
            var contato = new List<Contato>();

            /* Insira seus dados na lista */

            return contato;
        }
    }
}
