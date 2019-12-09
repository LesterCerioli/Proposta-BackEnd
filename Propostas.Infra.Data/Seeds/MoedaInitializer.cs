namespace Propostas.Infra.Data.Seeds
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Propostas.Domain.Models;
    using Propostas.Infra.Data.Context;

    public class MoedaInitializer
    {
        private PropostasContext context;
        private ICollection<Moeda> moedas;

        public MoedaInitializer(PropostasContext context)
        {
            this.context = context;
        }

        public async Task Seed()
        {
            this.moedas = this.Generate();
            var moedasIncluidas = this.context.Moedas.ToList();

            foreach (var moeda in this.moedas)
            {
                if (!moedasIncluidas.Any(c => c.Nome == moeda.Nome))
                {
                    this.context.Add(moeda);
                }
            }

            await this.context.SaveChangesAsync();

        }

        private ICollection<Moeda> Generate()
        {
            var moedas = new List<Moeda>();

            /* Insira seus dados na lista */
            moedas.Add(new Moeda() { Nome = "BRL" });
            moedas.Add(new Moeda() { Nome = "USD" });

            return moedas;
        }
    }
}
