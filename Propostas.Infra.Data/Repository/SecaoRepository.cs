namespace Propostas.Infra.Data.Repository
{
    using Propostas.Domain.Interfaces;
    using Propostas.Domain.Models;
    using Propostas.Infra.Data.Context;

    /// <summary>
    ///     Implementação da <see cref="ISecaoRepository"/>.
    /// </summary>
    public class SecaoRepository : BaseRepository<Secao>, ISecaoRepository
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="SecaoRepository"/> class.
        ///     Construtor padrão de <see cref="SecaoRepository"/>.
        /// </summary>
        /// <param name="context">
        ///     O contexto do repositório. Veja <see cref="PropostasContext"/>.
        /// </param>
        public SecaoRepository(PropostasContext context)
            : base(context)
        {
        }
    }
}
