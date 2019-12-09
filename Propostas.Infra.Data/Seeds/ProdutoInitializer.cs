namespace Propostas.Infra.Data.Seeds
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Propostas.Domain.Models;
    using Propostas.Infra.Data.Context;

    public class ProdutoInitializer
    {
        private PropostasContext context;
        private ICollection<Produto> produtos;

        public ProdutoInitializer(PropostasContext context)
        {
            this.context = context;
        }

        public async Task Seed()
        {
            this.produtos = this.Generate();

            /*
            var allProdutos = this.context.Produtos.ToList();
            foreach (var produto in _produtos)
            {
                if (!allProdutos.Any(c => c.Code == country.Code))
                {
                    this.context.Add(produto);
                }
            }

            */

            await this.context.SaveChangesAsync();
        }

        private ICollection<Produto> Generate()
        {
            var produto = new List<Produto>();

            /* Insira seus dados na lista */

            return produto;
        }
    }
}
