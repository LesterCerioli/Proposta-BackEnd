namespace Propostas.Infra.Data.Seeds
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Propostas.Domain.Models;
    using Propostas.Infra.Data.Context;

    public class EstadoInitializer
    {
        private PropostasContext context;
        private ICollection<Estado> estados;

        public EstadoInitializer(PropostasContext context)
        {
            this.context = context;
        }

        public async Task Seed()
        {
            this.estados = this.GenerateEstados();

            var allEstados = this.context.Estados.ToList();
            foreach (var estado in this.estados)
            {
                if (!allEstados.Any(c => c.Uf == estado.Uf))
                {
                    this.context.Add(estado);
                }
            }

            await this.context.SaveChangesAsync();
        }

        private ICollection<Estado> GenerateEstados()
        {
            var estados = new List<Estado>();
            var brasil = this.context.Paises.FirstOrDefault(c => c.Codigo == "BRA");
            if (brasil != null)
            {
                estados.Add(new Estado("Acre", "AC", 12, brasil));
                estados.Add(new Estado("Alagoas", "AL", 27, brasil));
                estados.Add(new Estado("Amapá", "AP", 16, brasil));
                estados.Add(new Estado("Amazonas", "AM", 13, brasil));
                estados.Add(new Estado("Bahia", "BA", 29, brasil));
                estados.Add(new Estado("Ceará", "CE", 23, brasil));
                estados.Add(new Estado("Distrito Federal", "DF", 53, brasil));
                estados.Add(new Estado("Espírito Santo", "ES", 32, brasil));
                estados.Add(new Estado("Goiás", "GO", 52, brasil));
                estados.Add(new Estado("Maranhão", "MA", 21, brasil));
                estados.Add(new Estado("Mato Grosso", "MT", 51, brasil));
                estados.Add(new Estado("Mato Grosso do Sul", "MS", 50, brasil));
                estados.Add(new Estado("Minas Gerais", "MG", 31, brasil));
                estados.Add(new Estado("Pará", "PA", 15, brasil));
                estados.Add(new Estado("Paraíba", "PB", 25, brasil));
                estados.Add(new Estado("Paraná", "PR", 41, brasil));
                estados.Add(new Estado("Pernambuco", "PE", 26, brasil));
                estados.Add(new Estado("Piauí", "PI", 22, brasil));
                estados.Add(new Estado("Rio de Janeiro", "RJ", 33, brasil));
                estados.Add(new Estado("Rio Grande do Norte", "RN", 24, brasil));
                estados.Add(new Estado("Rio Grande do Sul", "RS", 43, brasil));
                estados.Add(new Estado("Rondônia", "RO", 11, brasil));
                estados.Add(new Estado("Roraima", "RR", 14, brasil));
                estados.Add(new Estado("Santa Catarina", "SC", 42, brasil));
                estados.Add(new Estado("São Paulo", "SP", 35, brasil));
                estados.Add(new Estado("Sergipe", "SE", 28, brasil));
                estados.Add(new Estado("Tocantins", "TO", 17, brasil));
            }

            return estados.OrderBy(s => s.Nome).ToList();
        }
    }
}
