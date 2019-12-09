namespace Propostas.Infra.Data.Seeds
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Propostas.Domain.Models;
    using Propostas.Infra.Data.Context;

    public class TipoSecaoInitializer
    {
        private PropostasContext context;
        private ICollection<TipoSecao> tiposecaos;

        public TipoSecaoInitializer(PropostasContext context)
        {
            this.context = context;
        }

        public async Task Seed()
        {
            this.tiposecaos = this.Generate();
            var allTipoSecaos = this.context.TipoSecaos.ToList();
            foreach (var tiposecao in this.tiposecaos)
            {
                if (!allTipoSecaos.Any(c => c.Nome == tiposecao.Nome))
                {
                    this.context.Add(tiposecao);
                }
            }

           

            await this.context.SaveChangesAsync();
        }

        private ICollection<TipoSecao> Generate()
        {
            var tiposecao = new List<TipoSecao>();

            tiposecao.Add(new TipoSecao() { Nome = "Cover", Obrigatorio = true, Formato = "All" });
            tiposecao.Add(new TipoSecao() { Nome = "Company Presentation", Obrigatorio = true, Formato = "All" });
            tiposecao.Add(new TipoSecao() { Nome = "Scope", Obrigatorio = true, Formato = "Tecnica" });
            tiposecao.Add(new TipoSecao() { Nome = "Methodology & Process", Obrigatorio = true, Formato = "Tecnica" });
            tiposecao.Add(new TipoSecao() { Nome = "Workplan", Obrigatorio = true, Formato = "Tecnica" });
            tiposecao.Add(new TipoSecao() { Nome = "Roles & Responsibilities", Obrigatorio = true, Formato = "Tecnica" });
            tiposecao.Add(new TipoSecao() { Nome = "Contractual Conditions", Obrigatorio = true, Formato = "Tecnica" });
            tiposecao.Add(new TipoSecao() { Nome = "Investment", Obrigatorio = true, Formato = "Comercial" });
            tiposecao.Add(new TipoSecao() { Nome = "Accept & Sign", Obrigatorio = true, Formato = "All" });

            return tiposecao;
        }
    }
}
