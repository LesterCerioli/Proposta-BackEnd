namespace Propostas.Infra.Data.Seeds
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Propostas.Domain.Models;
    using Propostas.Infra.Data.Context;

    public class RecursoInitializer
    {
        private PropostasContext context;
        private ICollection<Recurso> recursos;

        public RecursoInitializer(PropostasContext context)
        {
            this.context = context;
        }

        public async Task Seed()
        {
            this.recursos = this.Generate();

            /*
            var allRecursos = this.context.Recursos.ToList();
            foreach (var recurso in _recursos)
            {
                if (!allRecursos.Any(c => c.Code == country.Code))
                {
                    this.context.Add(recurso);
                }
            }

            */

            await this.context.SaveChangesAsync();
        }

        private ICollection<Recurso> Generate()
        {
            var recurso = new List<Recurso>();
            


            return recurso;
        }
    }
}
