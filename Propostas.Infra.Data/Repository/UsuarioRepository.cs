namespace Propostas.Infra.Data.Repository
{
    using Propostas.Domain.Interfaces;
    using Propostas.Domain.Models;
    using Propostas.Infra.Data.Context;

    /// <summary>
    ///     Implementação da <see cref="IUsuarioRepository"/>.
    /// </summary>
    public class UsuarioRepository : BaseRepository<Usuario>, IUsuarioRepository
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="UsuarioRepository"/> class.
        ///     Construtor padrão de <see cref="UsuarioRepository"/>.
        /// </summary>
        /// <param name="context">
        ///     O contexto do repositório. Veja <see cref="PropostasContext"/>.
        /// </param>
        public UsuarioRepository(PropostasContext context)
            : base(context)
        {
        }
    }
}
