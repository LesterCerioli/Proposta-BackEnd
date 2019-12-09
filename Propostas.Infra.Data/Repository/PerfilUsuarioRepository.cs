namespace Propostas.Infra.Data.Repository
{
    using Propostas.Domain.Interfaces;
    using Propostas.Domain.Models;
    using Propostas.Infra.Data.Context;

    /// <summary>
    ///     Implementação da <see cref="IPerfilUsuarioRepository"/>.
    /// </summary>
    public class PerfilUsuarioRepository : BaseRepository<PerfilUsuario>, IPerfilUsuarioRepository
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="PerfilUsuarioRepository"/> class.
        ///     Construtor padrão de <see cref="PerfilUsuarioRepository"/>.
        /// </summary>
        /// <param name="context">
        ///     O contexto do repositório. Veja <see cref="PropostasContext"/>.
        /// </param>
        public PerfilUsuarioRepository(PropostasContext context)
            : base(context)
        {
        }
    }
}
