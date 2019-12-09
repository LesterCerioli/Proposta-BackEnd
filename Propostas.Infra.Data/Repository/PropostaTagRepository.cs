namespace Propostas.Infra.Data.Repository
{
    using Propostas.Domain.Interfaces;
    using Propostas.Domain.Models;
    using Propostas.Infra.Data.Context;

    /// <summary>
    ///     Implementação da <see cref="IPropostaTagRepository"/>.
    /// </summary>
    public class PropostaTagRepository : BaseRepository<PropostaTag>, IPropostaTagRepository
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="PropostaTagRepository"/> class.
        ///     Construtor padrão de <see cref="PropostaTagRepository"/>.
        /// </summary>
        /// <param name="context">
        ///     O contexto do repositório. Veja <see cref="PropostasContext"/>.
        /// </param>
        public PropostaTagRepository(PropostasContext context)
            : base(context)
        {
        }
    }
}
