namespace Propostas.Infra.Data.Repository
{
    using Propostas.Domain.Interfaces;
    using Propostas.Domain.Models;
    using Propostas.Infra.Data.Context;

    /// <summary>
    ///     Implementação da <see cref="ITipoSecaoRepository"/>.
    /// </summary>
    public class TipoSecaoRepository : BaseRepository<TipoSecao>, ITipoSecaoRepository
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="TipoSecaoRepository"/> class.
        ///     Construtor padrão de <see cref="TipoSecaoRepository"/>.
        /// </summary>
        /// <param name="context">
        ///     O contexto do repositório. Veja <see cref="PropostasContext"/>.
        /// </param>
        public TipoSecaoRepository(PropostasContext context)
            : base(context)
        {
        }
    }
}
