namespace Propostas.Infra.Data.Seeds
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Propostas.Domain.Models;
    using Propostas.Infra.Data.Context;

    public class LinguagemInitializer
    {
        private PropostasContext context;
        private ICollection<Linguagem> linguagems;

        public LinguagemInitializer(PropostasContext context)
        {
            this.context = context;
        }
       

      
            public async Task Seed()
        {
            this.linguagems = this.Generate();
            var linguagensIncluidas = this.context.Linguagems.ToList();

                foreach (var linguagem in this.linguagems)
            {
                if (!linguagensIncluidas.Any(c => c.Nome == linguagem.Nome))
                {
                    this.context.Add(linguagem);
                }
            }

            
            await this.context.SaveChangesAsync();
        }

        private ICollection<Linguagem> Generate()
        {
            var linguagem = new List<Linguagem>();

            linguagem.Add(new Linguagem() { Nome = "pt-BR" });
            linguagem.Add(new Linguagem() { Nome = "en-US" });

            return linguagem;
        }
    }
}
