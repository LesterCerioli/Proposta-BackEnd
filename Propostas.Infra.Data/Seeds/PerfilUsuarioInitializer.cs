namespace Propostas.Infra.Data.Seeds
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Propostas.Domain.Models;
    using Propostas.Infra.Data.Context;

    public class PerfilUsuarioInitializer
    {
        private PropostasContext context;
        private ICollection<PerfilUsuario> perfilusuarios;

        public PerfilUsuarioInitializer(PropostasContext context)
        {
            this.context = context;
        }

        public async Task Seed()
        {
            this.perfilusuarios = this.Generate();

            
            var allPerfilUsuarios = this.context.PerfilUsuarios.ToList();
            foreach (var perfilusuario in this.perfilusuarios)
            {
                if (!allPerfilUsuarios.Any(c => c.Nome == perfilusuario.Nome))
                {
                    this.context.Add(perfilusuario);
                }
            }
            

            await this.context.SaveChangesAsync();
        }

        private ICollection<PerfilUsuario> Generate()
        {
            var perfilusuario = new List<PerfilUsuario>();

            perfilusuario.Add(new PerfilUsuario() { Nome = "Lider Proposta" });
            perfilusuario.Add(new PerfilUsuario() { Nome = "Lider Solução" });

            return perfilusuario;
        }
    }
}
