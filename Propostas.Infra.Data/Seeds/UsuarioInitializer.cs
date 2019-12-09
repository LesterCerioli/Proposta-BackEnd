namespace Propostas.Infra.Data.Seeds
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Propostas.Domain.Models;
    using Propostas.Infra.Data.Context;

    public class UsuarioInitializer
    {
        private PropostasContext context;
        private ICollection<Usuario> usuarios;

        public UsuarioInitializer(PropostasContext context)
        {
            this.context = context;
        }

        public async Task Seed()
        {
            this.usuarios = this.Generate();

            /*
            var allUsuarios = this.context.Usuarios.ToList();
            foreach (var usuario in _usuarios)
            {
                if (!allUsuarios.Any(c => c.Code == country.Code))
                {
                    this.context.Add(usuario);
                }
            }

            */

            await this.context.SaveChangesAsync();
        }

        private ICollection<Usuario> Generate()
        {
            var usuario = new List<Usuario>();

            /* Insira seus dados na lista */

            return usuario;
        }
    }
}
