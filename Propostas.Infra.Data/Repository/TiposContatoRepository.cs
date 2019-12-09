namespace Propostas.Infra.Data.Repository
{
    using Propostas.Domain.Interfaces;
    using Propostas.Domain.Models;
    using Propostas.Infra.Data.Context;

    /// <summary>
    ///     Implementação da <see cref="ITiposContatoRepository"/>.
    /// </summary>
    public class TiposContatoRepository : BaseRepository<TiposContato>, ITiposContatoRepository
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="TiposContatoRepository"/> class.
        ///     Construtor padrão de <see cref="TiposContatoRepository"/>.
        /// </summary>
        /// <param name="context">
        ///     O contexto do repositório. Veja <see cref="PropostasContext"/>.
        /// </param>
        public TiposContatoRepository(PropostasContext context)
            : base(context)
        {
        }
    }
}
