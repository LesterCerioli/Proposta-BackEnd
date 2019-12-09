namespace Propostas.Infra.Data.Seeds
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Propostas.Domain.Models;
    using Propostas.Infra.Data.Context;

    public class TipoTemplateInitializer
    {
        private PropostasContext context;
        private ICollection<TipoTemplate> tipotemplates;

        public TipoTemplateInitializer(PropostasContext context)
        {
            this.context = context;
        }

        public async Task Seed()
        {
            this.tipotemplates = this.Generate();
            
            var allTipoTemplates = this.context.TipoTemplates.ToList();
            foreach (var tipotemplate in this.tipotemplates)
            {
                if (!allTipoTemplates.Any(c => c.Nome == tipotemplate.Nome))
                {
                    this.context.Add(tipotemplate);
                }
            }



            await this.context.SaveChangesAsync();
        }

        private ICollection<TipoTemplate> Generate()
        {
            var tipotemplate = new List<TipoTemplate>();
            
            tipotemplate.Add(new TipoTemplate() { Nome = "AMS SAP" });
            tipotemplate.Add(new TipoTemplate() { Nome = "AMS Mastersaf" });
            tipotemplate.Add(new TipoTemplate() { Nome = "AMS Microsoft" });
            tipotemplate.Add(new TipoTemplate() { Nome = "Projeto Fechado SAP" });
            tipotemplate.Add(new TipoTemplate() { Nome = "Projeto Fechado Microsoft" });
            tipotemplate.Add(new TipoTemplate() { Nome = "Projeto Fechado Mastersaf" });
            tipotemplate.Add(new TipoTemplate() { Nome = "Projeto Fechado Mobile" });
            tipotemplate.Add(new TipoTemplate() { Nome = "Alocação" });
            
            return tipotemplate;
        }
    }
}
