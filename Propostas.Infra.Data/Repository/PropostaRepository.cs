namespace Propostas.Infra.Data.Repository
{
    using Propostas.Domain.Interfaces;
    using Propostas.Domain.Models;
    using Propostas.Infra.Data.Context;

    /// <summary>
    ///     Implementação da <see cref="IPropostaRepository"/>.
    /// </summary>
    public class PropostaRepository : BaseRepository<Proposta>, IPropostaRepository
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="PropostaRepository"/> class.
        ///     Construtor padrão de <see cref="PropostaRepository"/>.
        /// </summary>
        /// <param name="context">
        ///     O contexto do repositório. Veja <see cref="PropostasContext"/>.
        /// </param>
        public PropostaRepository(PropostasContext context)
            : base(context)
        {
        }
    }
}
