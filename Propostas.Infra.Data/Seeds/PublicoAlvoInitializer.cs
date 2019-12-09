namespace Propostas.Infra.Data.Seeds
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Propostas.Domain.Models;
    using Propostas.Infra.Data.Context;

    public class PublicoAlvoInitializer
    {
        private PropostasContext context;
        private ICollection<PublicoAlvo> publicoalvos;

        public PublicoAlvoInitializer(PropostasContext context)
        {
            this.context = context;
        }

        public async Task Seed()
        {
            this.publicoalvos = this.Generate();
            var allPublicoAlvos = this.context.PublicoAlvos.ToList();

            foreach (var publicoalvo in this.publicoalvos)
            {
                if (!allPublicoAlvos.Any(c => c.Nome == publicoalvo.Nome))
                {
                    this.context.Add(publicoalvo);
                }
            }



            await this.context.SaveChangesAsync();
        }

        private ICollection<PublicoAlvo> Generate()
        {
            var publicoalvo = new List<PublicoAlvo>();

            publicoalvo.Add(new PublicoAlvo() { Nome = "Comercial" });
            publicoalvo.Add(new PublicoAlvo() { Nome = "Técnico" });

            return publicoalvo;
        }
    }
}
