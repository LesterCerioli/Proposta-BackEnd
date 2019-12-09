namespace Propostas.Infra.Data.Seeds
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Propostas.Domain.Models;
    using Propostas.Infra.Data.Context;

    public class TiposContatoInitializer
    {
        private PropostasContext context;
        private ICollection<TiposContato> tiposcontatos;

        public TiposContatoInitializer(PropostasContext context)
        {
            this.context = context;
        }

        public async Task Seed()
        {
            this.tiposcontatos = this.Generate();
            var allTiposContatos = this.context.TiposContatos.ToList();
            foreach (var tiposcontato in this.tiposcontatos)
            {
                if (!allTiposContatos.Any(c => c.Nome == tiposcontato.Nome))
                {
                    this.context.Add(tiposcontato);
                }
            }



            await this.context.SaveChangesAsync();
        }

        private ICollection<TiposContato> Generate()
        {
            var tiposcontato = new List<TiposContato>();

            /* Insira seus dados na lista */
            tiposcontato.Add(new TiposContato() { Nome = "Comercial" });
            tiposcontato.Add(new TiposContato() { Nome = "Técnico" });
            tiposcontato.Add(new TiposContato() { Nome = "Comercial ou Técnico" });

            return tiposcontato;
        }
    }
}
