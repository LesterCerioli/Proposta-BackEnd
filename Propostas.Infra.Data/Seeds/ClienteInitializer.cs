namespace Propostas.Infra.Data.Seeds
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Propostas.Domain.Models;
    using Propostas.Infra.Data.Context;

    public class ClienteInitializer
    {
        private PropostasContext context;
        private ICollection<Cliente> clientes;

        public ClienteInitializer(PropostasContext context)
        {
            this.context = context;
        }

        public async Task Seed()
        {
            this.clientes = this.Generate();

            /*
            var allClientes = this.context.Clientes.ToList();
            foreach (var cliente in _clientes)
            {
                if (!allClientes.Any(c => c.Code == country.Code))
                {
                    this.context.Add(cliente);
                }
            }

            */

            await this.context.SaveChangesAsync();
        }

        private ICollection<Cliente> Generate()
        {
            var cliente = new List<Cliente>();

            /* Insira seus dados na lista */

            return cliente;
        }
    }
}
